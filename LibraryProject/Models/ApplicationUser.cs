using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace LibraryProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Year { get; set; }

        //Added user position(Admin/User)
        //public string Name { get; set; }

        public ApplicationUser()
        {

        }
        //Added to save claim data in coockie
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            var yearClaim = Claims.FirstOrDefault(c => c.ClaimType == "Year");
            if (yearClaim != null)
                userIdentity.AddClaim(new Claim(yearClaim.ClaimType, yearClaim.ClaimValue));
            return userIdentity;
        }
    }
}