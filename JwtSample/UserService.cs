using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtSample
{
    internal class UserService
    {

        private const string SecretCode = "kYp3s6v9y/B?E(H+";

        private IDictionary<string, string> _users = new Dictionary<string, string>()
        {
            {"user1", "test1" }, // 0
            {"user2", "test1" }, // 1
            {"user3", "test1" }, // 2
            {"user4", "test1" }, // 3
            {"user5", "test1" }  // 4
        };

        public string Login(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(password))
            {
                return string.Empty;

            }

            int i = 0;
            foreach (var user in _users)
            {
                if (string.CompareOrdinal(user.Key, login) == 0 &&
                    string.CompareOrdinal(user.Value, password) == 0)
                {
                    return GenerateJwtToken(i, login);
                }

                i++;
            }

            return string.Empty;

        }

        private string GenerateJwtToken(int id, string userName)
        {
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(SecretCode);

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor();
            securityTokenDescriptor.Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, id.ToString())
            });
            securityTokenDescriptor.Expires = DateTime.UtcNow.AddMinutes(15);
            securityTokenDescriptor.SigningCredentials = 
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }


    }
}
