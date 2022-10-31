using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Model
{
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole()
            : base()
        { }
        public AppRole(string roleName)
            : base(roleName)
        { }
    }
}
