using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.Text;
using TalabatCore.Entites;
using TalabatCore.Servise;
using TalabatServise;
using TlabatRepository.identitymi;

namespace Talabat.Extention
{
    public static class appidentityextention
    {
        public static IServiceCollection identityservuse(this IServiceCollection servise,IConfiguration _configuration)
        {
            servise.AddScoped(typeof(ITokenservise), typeof(TokenServise));
            servise.AddIdentity<AppUser, IdentityRole>(option =>
            option.Password.RequireDigit = true)
                .AddEntityFrameworkStores<AppIdentityDbcontext>();

              

            servise.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
               option.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateIssuer =true,
                   ValidIssuer = _configuration["Jwt:Issur"],
                   ValidateAudience =true,
                   ValidAudience =_configuration["Jwt:Audiance"],
                   ValidateLifetime =true,
                   ValidateIssuerSigningKey = true, 
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:kEY"]))
        }
                );
            return servise;
        }
    }
}
