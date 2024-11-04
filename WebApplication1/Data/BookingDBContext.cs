using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Claims;
using BookingService.Models;

namespace BookingService.Data
{
    public class BookingDBContext : DbContext
    {
        public IConfiguration _config { get; set; }
        public BookingDBContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        }
        public BookingDBContext(DbContextOptions<BookingDBContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Packages> Packages { get; set; }
        public DbSet<UserPackages> UserPackages { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<WaitList> Waitlists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints here
        }
    }
}
