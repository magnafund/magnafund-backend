using ModelLibrary;

namespace Donations.API.Models.Repository
{
    public interface IDonationRepository
    {
        Task<Result<IEnumerable<Donation>>> GetAllAsync();
        Task<Result<Donation>> GetByIdAsync(int id);
        Task<Result<IEnumerable<Donation>>> GetByUserIdAsync(int userId);
        Task<Result<IEnumerable<Donation>>> GetByCategoryIdAsync(List<int> categoryId);
        Task<Result<IEnumerable<Donation>>> GetTopDonationsAsync();
        Task<Result<Donation>> AddDonationAsync(Donation donation);
        Task<Result<Donation>> UpdateDonationAsync(Donation donation);
        Task<Result<Donation>> UpdateÌmageAsync(Donation donation);
        Task<Result<Donation>> RevokeDonationAsync(int id);
    }
}
