using ModelLibrary;

namespace Donations.API.Models.Repository
{
    public interface IDonationRepository
    {
        Task<Result<IEnumerable<Donation>>> GetAllAsync();
        Task<Result<Donation>> GetByIdAsync(int id);
        Task<Result<Donation>> AddDonationAsync(Donation donation);
    }
}
