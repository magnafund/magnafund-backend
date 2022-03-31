using ModelLibrary;

namespace Donations.API.Models.Repository
{
    public class DonationCategoryRepository : IDonationCategoryRepository
    {
        public Task<Result<Category>> AddAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Category>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<Category>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Category>> UpdateAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}