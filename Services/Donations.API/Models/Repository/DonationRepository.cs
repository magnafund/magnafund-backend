using Donations.API.Enums;
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

        public async Task<Result<Donation>> GetByIdAsync(int id)
        {
            var donation = await _context.Donations!.Where(x => x.Id == id).SingleOrDefaultAsync();
            return new Result<Donation>(donation!);
        }

        public async Task<Result<IEnumerable<Donation>>> GetByUserIdAsync(int userId)
        {
            var donations = await _context.Donations!.Where(x => x.UserId == userId).ToListAsync();
            return new Result<IEnumerable<Donation>>(donations);
        }

        public async Task<Result<IEnumerable<Donation>>> GetByCategoryIdAsync(List<int> categoryIds)
        {
            var donations = await _context.Donations!
                                          .Where(x => categoryIds.Any(id => id == x.CategoryId))
                                          .ToListAsync();

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

        public async Task<Result<Donation>> UpdateDonationAsync(Donation donation)
        {
            try
            {
                _context.Update(donation);
                await _context.SaveChangesAsync();
                return new Result<Donation>(donation, new List<string>() { "Donation updated succesfully!"});
            }
            catch (Exception)
            {
                return new Result<Donation>(false, new List<string>() { "Failed to update. Try again!" });
            }
        }

        public async Task<Result<Donation>> RevokeDonationAsync(int id)
        {
            var donation = await _context.Donations!.Where(x => x.Id == id).FirstOrDefaultAsync();
            await _context.SaveChangesAsync();
            donation!.Status = DonationStatus.Blocked;
            _context.Donations!.Update(donation);

            return new Result<Donation>(donation);
        }
    }
}