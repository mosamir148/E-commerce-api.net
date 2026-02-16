using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TalabatCore.Entites;
using TalabatCore.Servise;

namespace TalabatServise
{
    public class TokenServise :ITokenservise
    {
        private readonly IConfiguration configuration;

        public TokenServise(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        

        public async Task<string> Createtoken(AppUser user, UserManager<AppUser> userManager)
        {
            var authclaim = new List<Claim>()
            {
             new Claim(ClaimTypes.Email,user.Email),
             new Claim(ClaimTypes.Name,user.DisplayName)
            };
            var getrole = await userManager.GetRolesAsync(user);
           foreach (var role in getrole)
            {
                authclaim.Add(new Claim(ClaimTypes.Role, role));
            }

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:kEY"]));

            var Token = new JwtSecurityToken(

                issuer: configuration["Jwt:Issur"],
                audience: configuration["Jwt:Audiance"],
                expires: DateTime.UtcNow.AddDays(double.Parse(configuration["Jwt:durationinday"])),
                claims: authclaim,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256)

            );

             return  new JwtSecurityTokenHandler().WriteToken(Token);



        }
    }
}
