using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatCore.Entites;

namespace TalabatCore.Servise
{
    public interface ITokenservise
    {
        Task<string> Createtoken(AppUser appUser, UserManager<AppUser> userManager);
    }
}
