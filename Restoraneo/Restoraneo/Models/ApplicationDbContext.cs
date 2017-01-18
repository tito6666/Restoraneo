using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Restoraneo.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<RestaurantDish> RestaurantDish { get; set; }

        public DbSet<RestaurantInfo> RestaurantInfo { get; set; }

        public DbSet<ReservationClaim> ReservationClaim { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Restaurant>()
             .HasOptional(pi => pi.RestaurantInfo)
             .WithRequired(lu => lu.Restaurant);

            modelBuilder.Entity<RestaurantInfo>().ToTable("RestaurantInfos");

            base.OnModelCreating(modelBuilder);
        }
    }
}