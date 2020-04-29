using JWTCoreDemo.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTCoreDemo.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        readonly private AppSettings _aapSettings;
        public AuthenticationService(IOptions<AppSettings> appSettings)
        {
            _aapSettings = appSettings.Value;
        }

        private List<User> users = new List<User>(){
            new User{UserId="1",FirstName="Pramod",LastName="Vishwakarma",UserName="PK",Password="12345" }
        };
        public User Authenticate(string userName, string password)
        {

            var user = users.SingleOrDefault(x => x.UserName == userName && x.Password == password);

            //Return null if user not found

            if (user == null)
                return null;

            //If user found

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_aapSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V3.1")
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = null;
            return user;
        }
    }
}
