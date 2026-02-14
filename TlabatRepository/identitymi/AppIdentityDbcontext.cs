using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatCore.Entites;

namespace TlabatRepository.identitymi
{
    public class AppIdentityDbcontext:IdentityDbContext<AppUser>
    {
        public AppIdentityDbcontext(DbContextOptions<AppIdentityDbcontext> options):base(options)
        {
            
        }


    }
}
