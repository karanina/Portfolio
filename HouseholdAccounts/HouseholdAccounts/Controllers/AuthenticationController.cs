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

namespace HouseholdAccounts.Controllers
{
    [Authorize] // tells the controller to authorise the user when they access the controller (ie they need a token to access the controller,
                // unless opted out as anonymous)
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly DataContextDapper _dapper;
        private readonly AuthenticationHelper _authenticationHelper;
        public AuthenticationController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
            _authenticationHelper = new AuthenticationHelper(config);
        }

        [AllowAnonymous] // lets this endpoint receive an anonymous request, ie one where they don't have a token
        [HttpPost("Register")]
        public IActionResult Register(UserForRegistrationDTO userForRegistration)
        {
            if (userForRegistration.Password == userForRegistration.PasswordConfirm)
            {
                string sqlCheckUserExists = @$"SELECT [Email] 
                                                FROM [dbo].[Authentication] WHERE Email = '{userForRegistration.Email}'";

                IEnumerable<string> existingUsers = _dapper.LoadData<string>(sqlCheckUserExists);

                if (existingUsers.Count() == 0)
                {
                    byte[] passwordSalt = new byte[128 / 8]; // 128 bytes

                    using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                    {
                        rng.GetNonZeroBytes(passwordSalt);
                    }

                    byte[] passwordHash = _authenticationHelper.GetPasswordHash(userForRegistration.Password, passwordSalt);

                    string sqlAddAuthentication = @$"INSERT INTO [dbo].[Authentication] (
                                                        [Email],
                                                        [PasswordHash],
                                                        [PasswordSalt]
                                                    ) VALUES (
                                                        '{userForRegistration.Email}',
                                                        @PasswordHash,
                                                        @PasswordSalt
                                                    )";

                    List<SqlParameter> sqlParameters = new List<SqlParameter>();

                    SqlParameter passwordSaltParameter = new SqlParameter("@PasswordSalt", SqlDbType.VarBinary);
                    passwordSaltParameter.Value = passwordSalt;

                    SqlParameter passwordHashParameter = new SqlParameter("@PasswordHash", SqlDbType.VarBinary);
                    passwordHashParameter.Value = passwordHash;

                    sqlParameters.Add(passwordSaltParameter);
                    sqlParameters.Add(passwordHashParameter);

                    if (_dapper.ExecuteSqlWithParameters(sqlAddAuthentication, sqlParameters))
                    {
                        // setting active to 1 / True by default when adding a user
                        string sqlAddUser = @$"
                                            INSERT INTO dbo.Users (
                                                Username, 
                                                FirstName, 
                                                LastName, 
                                                Email, 
                                                Active
                                            ) VALUES (
                                                '{userForRegistration.Username}',
                                                '{userForRegistration.FirstName}',
                                                '{userForRegistration.LastName}',
                                                '{userForRegistration.Email}',            
                                                1
                                            )";

                        if (_dapper.ExecuteSql(sqlAddUser))
                        {
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

        [AllowAnonymous] // lets this endpoint receive an anonymous request, ie one where they don't have a token
        [HttpPost("Login")]
        public IActionResult Login(UserForLoginDTO userForLogin)
        {
            string sqlForHashAndSalt = $@"SELECT [PasswordHash], 
                                            [PasswordSalt]
                                        FROM [dbo].[Authentication]
                                        WHERE Email = '{userForLogin.Email}'";

            UserForLoginConfirmationDTO userForConfirmation = _dapper
                .LoadDataSingle<UserForLoginConfirmationDTO>(sqlForHashAndSalt);

            byte[] passwordHash = _authenticationHelper.GetPasswordHash(userForLogin.Password, userForConfirmation.PasswordSalt);

            for (int i = 0; i < passwordHash.Length; i++)
            {
                if (passwordHash[i] != userForConfirmation.PasswordHash[i])
                {
                    return StatusCode(401, "Incorrect password!");
                }
            }

            string sqlForUserId = @$"SELECT UserId 
                                    FROM [dbo].[Users] 
                                    WHERE Email = '{userForLogin.Email}'";

            int userId = _dapper.LoadDataSingle<int>(sqlForUserId);

            return Ok(new Dictionary<string, string>
            {
                {"token", _authenticationHelper.CreateToken(userId) }
            });
        }

        [HttpGet("RefreshToken")]
        public IActionResult RefreshToken()
        {
            // string because claims are stored in a string format
            string userId = User.FindFirst("userId")?.Value + ""; // User comes from controller base class

            // check if the userId claim value is valid in our database. If it is we're ok to give a new token.
            string SqlForUserId = @$"SELECT UserId 
                                    FROM [dbo].[Users] 
                                    WHERE UserId = {userId}";

            int userIdFromDb = _dapper.LoadDataSingle<int>(SqlForUserId);

            return Ok(new Dictionary<string, string>
            {
                {"token", _authenticationHelper.CreateToken(userIdFromDb) }
            });
        }
    }
}

