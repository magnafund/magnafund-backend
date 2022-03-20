using Donations.API.Models.Data;
using Microsoft.EntityFrameworkCore;
using ModelLibrary;

namespace Donations.API.Models.Repository
{
    public class DonationRepository : IDonationRepository
    {
        private readonly ApplicationDbContext _context;

        public DonationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<IEnumerable<Donation>>> GetAllAsync()
        {
            var donations = await _context.Donations!.ToListAsync();
            return new Result<IEnumerable<Donation>>(donations);
        }

        public async Task<Result<Donation>> AddDonationAsync(Donation donation)
        {
            return null;
        }
    }
}
