using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HouseholdAccounts.Helpers
{
    public class AuthenticationHelper
    {
        private readonly IConfiguration _config;

        public AuthenticationHelper(IConfiguration config)
        {
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

        public string CreateToken(int userId)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("userId", userId.ToString())
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
    }
}
