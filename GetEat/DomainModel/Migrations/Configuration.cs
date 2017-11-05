namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DomainModel.GetEatContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DomainModel.GetEatContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Kitchens.Add(new Entities.Kitchen
            {
                Name = "Sushi",
                Description = "Sushi",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });
            context.Kitchens.Add(new Entities.Kitchen
            {
                Name = "Burger",
                Description = "Burger",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });

            context.SaveChanges();
            //
        }
    }
}
