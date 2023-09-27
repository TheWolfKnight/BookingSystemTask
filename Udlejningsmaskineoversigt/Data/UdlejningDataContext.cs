using Microsoft.EntityFrameworkCore;
using Abstraction.Models;

namespace Udlejningsmaskineoversigt.Data {
    public class UdlejningDataContext : DbContext {

        public UdlejningDataContext(DbContextOptions<UdlejningDataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Udlejningsmaskiner;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Resource> Resources { get; set; }

    }
}