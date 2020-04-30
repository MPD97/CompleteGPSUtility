using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace Database.Entities
{
    public class AppUser : IdentityUser<int>
    {

        public virtual IEnumerable<Access> Accesses { get; set; }
    }
}