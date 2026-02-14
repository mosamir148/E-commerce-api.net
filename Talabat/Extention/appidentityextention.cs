using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using TalabatCore.Entites;
using TalabatCore.Servise;
using TalabatServise;
using TlabatRepository.identitymi;

namespace Talabat.Extention
{
    public static class appidentityextention
    {
        public static IServiceCollection identityservuse(this IServiceCollection servise)
        {
            servise.AddScoped(typeof(ITokenservise), typeof(TokenServise));
            servise.AddIdentity<AppUser, IdentityRole>(option =>
            option.Password.RequireDigit = true)
                .AddEntityFrameworkStores<AppIdentityDbcontext>();

              

            servise.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();
            return servise;
        }
    }
}
