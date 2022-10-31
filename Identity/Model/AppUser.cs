using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Model
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
            : base()
        { }
    }
}
