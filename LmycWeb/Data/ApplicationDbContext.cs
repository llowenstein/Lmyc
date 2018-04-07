using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LmycWeb.Models;
using LmycWeb.Models.Boat;
using LmycWeb.Models.Reservation;

namespace LmycWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<LmycWeb.Models.ApplicationUser> ApplicationUser { get; set; }

        public DbSet<LmycWeb.Models.Boat.Boat> Boat { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
    }
}
