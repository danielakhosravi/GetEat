namespace GetEat.WebUI.Migrations
{
    using GetEat.WebUI.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GetEat.WebUI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GetEat.WebUI.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Adminstrator"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Adminstrator" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Customer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Customer" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Visitor"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Visitor" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "Adminstrator"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "daniela", Email = "daniela@khosravi.bg" };

                manager.Create(user, "Daniela123#");
                manager.AddToRole(user.Id, "Adminstrator");
            }

        }
    }
}
