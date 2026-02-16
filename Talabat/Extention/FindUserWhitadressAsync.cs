using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using TalabatCore.Entites;

namespace Talabat.Extention
{
    public static class FindUserWhitadressAsync
    {
        public static async Task<AppUser?> getuserwhithadressasync(this UserManager<AppUser> userManager,ClaimsPrincipal User)
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.Users.Include(x =>x.address).FirstOrDefaultAsync(u =>u.Email == Email);
            return user;
        }
    }
}
