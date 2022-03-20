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
            try
            {
                await _context.Donations!.AddAsync(donation);
                await _context.SaveChangesAsync();

                return new Result<Donation>(donation, new List<string>() { "Donation created succesfully!"});
            }
            catch (Exception)
            {
                return new Result<Donation>(false, new List<string>() { "Failed to create. Try again!" });
            }
        }
    }
}