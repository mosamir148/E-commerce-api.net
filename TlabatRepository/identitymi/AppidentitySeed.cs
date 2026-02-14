using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatCore.Entites;

namespace TlabatRepository.identitymi
{
    public static class AppidentitySeed
    {
        public async static Task seeduserasync(UserManager<AppUser> _userManager)
        {
            if (!_userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Moahemd samir",
                    Email = "msm318628@gmail.com",
                    UserName = "abosamra",
                    PhoneNumber = "1234567890"
                };

                 await _userManager.CreateAsync(user,"Pa$$0rd");
            }
                
                    
        }
    }
}
