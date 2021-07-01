using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTest.Web.Identity
{
    public class ApplicationRole
    : IdentityRole
    {
        public ApplicationRole(string name) : base(name)
        { }
        public ApplicationRole() : base()
        { }

        public bool? IsActive { get; set; }

    }
}
