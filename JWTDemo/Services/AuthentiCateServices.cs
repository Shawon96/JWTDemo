using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JWTDemo.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JWTDemo.Services
{
    public class AuthentiCateServices : IAuthentiCateServices
    {
        private readonly AppSettings _appSettings;

        public AuthentiCateServices(IOptions<AppSettings> appsetting)
        {
            this._appSettings = appsetting.Value;
        }
        private List<User> users = new List<User>()
        {
              new User{userId = 123, FirstName="shawon", LastName="Akand", UserName = "shawonBoss", Password= "shawon963"}
        };
        public User Authentication(string userName, string password)
        {
            var user = users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
            if(user == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.userId.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V3.1")
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var Token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(Token);
            user.Password = null;
            return user;
        }
    }
}
