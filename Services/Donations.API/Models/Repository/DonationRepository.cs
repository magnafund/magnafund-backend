using Donations.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Donations.API.Models.Repository
{
    public class DonationRepository : IDonationRepository
    {
        private readonly ApplicationDbContext _context;

        public DonationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Donation>> GetAllAsync() => await _context.Donations!.ToListAsync();

        public async Task<Donation> AddDonationAsync(Donation donation)
        {
            return null;
        }
    }
}
