using HouseholdAccounts.Data;
using HouseholdAccounts.DTOs;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HouseholdAccounts.Helpers
{
    public class AuthenticationHelper
    {
        private readonly IConfiguration _config;
        private readonly DataContextDapper _dapper;

        public AuthenticationHelper(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
            _config = config;
        }
        public byte[] GetPasswordHash(string password, byte[] passwordSalt)
        {
            // the AppSettings lives on the server, while the password salt will live in the database. Separation of
            // these two helps prevent hackers from creating a Rainbow table to work out a users hash value.
            string passwordSaltPlustString = _config.GetSection("AppSettings:PasswordKey").Value
                + Convert.ToBase64String(passwordSalt);

            // hashes the password using the salt
            return KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.ASCII.GetBytes(passwordSaltPlustString), // converts back to a byte array
                prf: KeyDerivationPrf.HMACSHA256, // (PRF) Pseudo Random Functionality, using the HMACSHAA256 algorithm to hash
                iterationCount: 100000,
                numBytesRequested: 256 / 8);
        }

        public string CreateToken(int userID)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("userID", userID.ToString())
            };

            string? tokenKeyString = _config.GetSection("AppSettings:TokenKey").Value;

            SymmetricSecurityKey tokenKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    tokenKeyString != null ? tokenKeyString : ""
                )
            );

            SigningCredentials credentials = new SigningCredentials(
                tokenKey,
                SecurityAlgorithms.HmacSha512Signature
            );

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials,
                Expires = DateTime.Now.AddDays(1) // token expires after 1 day
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(token);
        }

        public bool SetPassword(UserForLoginDTO userForSetPassword)
        {
            byte[] passwordSalt = new byte[128 / 8]; // 128 bytes

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetNonZeroBytes(passwordSalt);
            }

            byte[] passwordHash = GetPasswordHash(userForSetPassword.Password, passwordSalt);

            string sqlAddAuthentication = $@"EXEC[Accounts].[spAuthentication_Upsert] 
                                                @Email = @EmailParam,                                               
                                                @PasswordHash = @PasswordHashParam, 
                                                @PasswordSalt = @PasswordSaltParam";

            // use sqlParameters here as an example of sql parameters
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            // parameters like this protect against sql injection
            SqlParameter emailParameter = new SqlParameter("@EmailParam", SqlDbType.VarChar);
            emailParameter.Value = userForSetPassword.Email;
            sqlParameters.Add(emailParameter);

            SqlParameter passwordHashParameter = new SqlParameter("@PasswordHashParam", SqlDbType.VarBinary); // if using Dynamic Parameters, use DbType.Binary
            passwordHashParameter.Value = passwordHash;
            sqlParameters.Add(passwordHashParameter);

            SqlParameter passwordSaltParameter = new SqlParameter("@PasswordSaltParam", SqlDbType.VarBinary); // if using Dynamic Parameters, use DbType.Binary
            passwordSaltParameter.Value = passwordSalt;
            sqlParameters.Add(passwordSaltParameter);

            return _dapper.ExecuteSqlWithSqlParameters(sqlAddAuthentication, sqlParameters);
        }
    }
}
