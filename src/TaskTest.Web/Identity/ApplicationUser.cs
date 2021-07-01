using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTest.Web.Identity
{
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {
                
        }

        public bool? IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rank { get; set; }
        public string MelliCode { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
