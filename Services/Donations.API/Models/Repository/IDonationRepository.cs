namespace Donations.API.Models.Repository
{
    public interface IDonationRepository
    {
        Task<IEnumerable<Donation>> GetAllAsync();
        Task<Donation> AddDonationAsync(Donation donation);
    }
}
