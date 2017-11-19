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
            if (!context.Roles.Any(r => r.Name == RoleNames.Adminstrator))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = RoleNames.Adminstrator };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == RoleNames.Customer))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = RoleNames.Customer };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == RoleNames.Visitor))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = RoleNames.Visitor };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == RoleNames.Adminstrator))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = RoleNames.Adminstrator, Email = "daniela@khosravi.bg" };

                manager.Create(user, "Daniela123$");
                manager.AddToRole(user.Id, RoleNames.Adminstrator);
            }

        }
    }
}
