using Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isentity.Context
{
    public class IdentityRepositoryContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public IdentityRepositoryContext(DbContextOptions<IdentityRepositoryContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
    }
}
