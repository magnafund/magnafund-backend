using Microsoft.EntityFrameworkCore;

namespace Donations.API.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Donation>? Donations { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Payment>? Payments { get; set; }
    }
}