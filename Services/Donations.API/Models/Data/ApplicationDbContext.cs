using Microsoft.EntityFrameworkCore;

namespace Donations.API.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Donation>? Donations { get; set; }
    }
}