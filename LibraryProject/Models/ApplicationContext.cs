using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryProject.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("IdentityDb") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }

    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {

        protected override void Seed(ApplicationContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));


            //add 2 roles
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            //add to Db
            roleManager.Create(role1);
            roleManager.Create(role2);

            //Create Users
            var admin = new ApplicationUser { Email = "qwe@qwe.qwe", UserName = "qwe@qwe.qwe" };
            string password = "1_Qwerty";
            var result = userManager.Create(admin, password);

            // if Create succeeded
            if (result.Succeeded)
            {
                //add role for user
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }base.Seed(context);
        } 
    }
}