namespace Kursach3.Migrations
{
    using Kursach3.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Kursach3.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Kursach3.Models.ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var adminRole = new IdentityRole { Name = "admin" };
            var userRole = new IdentityRole { Name = "user" };
            roleManager.Create(adminRole);
            roleManager.Create(userRole);
            var admin = new ApplicationUser { Email = "admin@mail.ru", UserName = "admin", Login = "admin" };
            string password = "123456";
            var result = userManager.Create(admin, password);
            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, userRole.Name);
                userManager.AddToRole(admin.Id, adminRole.Name);
            }
            base.Seed(context);
        }
    }
}
