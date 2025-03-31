using HouseholdAccounts.Data;
using HouseholdAccounts.DTOs;
using HouseholdAccounts.Models;
using HouseholdAccounts.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Dapper;

namespace HouseholdAccounts.Controllers
{
    [Authorize] /// tells the controller to authorise the user when they access the controller (ie they need a token to access the controller,
                /// unless opted out as anonymous)
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly DataContextDapper _dapper;
        private readonly AuthenticationHelper _authenticationHelper;
        private readonly ReusableSql _reusableSql;
        private readonly IMapper _mapper;
        public AuthenticationController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
            _authenticationHelper = new AuthenticationHelper(config);
            _reusableSql = new ReusableSql(config);
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserForRegistrationDTO, User>();
            }));
        }

        [AllowAnonymous] // lets this endpoint receive an anonymous request, ie one where they don't have a token
        [HttpPost("Register")]
        public IActionResult Register(UserForRegistrationDTO userForRegistration)
        {
            if (userForRegistration.Password == userForRegistration.PasswordConfirm)
            {
                string sqlCheckUserExists = @$"SELECT [Email] 
                                                FROM [Accounts].[Authentication] WHERE Email = '{userForRegistration.Email}'";

                IEnumerable<string> existingUsers = _dapper.LoadData<string>(sqlCheckUserExists);

                if (existingUsers.Count() == 0)
                {
                   UserForLoginDTO userForSetPassword = new UserForLoginDTO()
                   {
                       Email = userForRegistration.Email,
                       Password = userForRegistration.Password,
                   };

                    if(_authenticationHelper.SetPassword(userForSetPassword))
                    {
                        User userToAdd = _mapper.Map<User>(userForRegistration);
                        // Active is not a property in UserForRegistrationDTO
                        userToAdd.Active = true;

                        if (_reusableSql.UpsertUser(userToAdd));
                        {
                            // Ok() comes from ControllerBase class, refers status code 200
                            return Ok();
                        }
                        throw new Exception("Failed to add User");
                    }
                    throw new Exception("Failed to register User");
                }
                throw new Exception("User with this email already exists!");
            }
            throw new Exception("Passwords do not match!");
        }

        [HttpPut("ResetPassword")]
        public IActionResult ResetPassword(UserForLoginDTO userForSetPassword) {
            if (_authenticationHelper.SetPassword(userForSetPassword))
            {
                return Ok();
            }
            throw new Exception("Failed to update password");
        }

        [AllowAnonymous] // lets this endpoint receive an anonymous request, ie one where they don't have a token
        [HttpPost("Login")]
        public IActionResult Login(UserForLoginDTO userForLogin)
        {
            string sqlForHashAndSalt = "EXEC Accounts.spLoginConfirmation_Get @Email = @EmailParam";

            DynamicParameters sqlParameters = new DynamicParameters();

            // using parameters like this protect against sql injection
            sqlParameters.Add("@EmailParam", userForLogin.Email, DbType.String);

            UserForLoginConfirmationDTO userForConfirmation = _dapper
                .LoadDataSingleWithParameters<UserForLoginConfirmationDTO>(sqlForHashAndSalt, sqlParameters);

            byte[] passwordHash = _authenticationHelper.GetPasswordHash(userForLogin.Password, userForConfirmation.PasswordSalt);

            for (int i = 0; i < passwordHash.Length; i++)
            {
                if (passwordHash[i] != userForConfirmation.PasswordHash[i])
                {
                    return StatusCode(401, "Incorrect password!");
                }
            }

            string sqlForUserId = @$"SELECT ID 
                                    FROM [Accounts].[Users] 
                                    WHERE Email = '{userForLogin.Email}'";

            int userID = _dapper.LoadDataSingle<int>(sqlForUserId);

            return Ok(new Dictionary<string, string>
            {
                {"token", _authenticationHelper.CreateToken(userID) }
            });
        }

        [HttpGet("RefreshToken")]
        public IActionResult RefreshToken()
        {
            // string because claims are stored in a string format
            string userID = User.FindFirst("userID")?.Value + ""; // User comes from controller base class

            // check if the userID claim value is valid in our database. If it is we're ok to give a new token.
            string SqlForUserID = @$"SELECT UserId 
                                    FROM [Accounts].[Users] 
                                    WHERE UserId = {userID}";

            int userIDFromDb = _dapper.LoadDataSingle<int>(SqlForUserID);

            return Ok(new Dictionary<string, string>
            {
                {"token", _authenticationHelper.CreateToken(userIDFromDb) }
            });
        }
    }
}

