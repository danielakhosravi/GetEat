using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class GetEatContext : DbContext
    {
        public GetEatContext()
            : base("GeteatContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restourant>()
            .HasMany(i => i.Reviews)
            .WithRequired().WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Organisation> Organisations { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Restourant> Restourants { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Kitchen> Kitchens { get; set; }

        public DbSet<Review> Reviews { get; set; }

    }
}
