using Donations.API.Models.Data;
using Microsoft.EntityFrameworkCore;
using ModelLibrary;

namespace Donations.API.Models.Repository
{
    public class DonationCategoryRepository : IDonationCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public DonationCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Category>> AddAsync(Category category)
        {
            try
            {
                await _context.AddAsync(category);
                await _context.SaveChangesAsync();
             
                return new Result<Category>(category, new List<string>() { "Category created succesfully!" });
            }
            catch (Exception)
            {
                return new Result<Category>(false, new List<string>() { "Failed to create. Try again!" });
            }
        }

        public Task<Result<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<IEnumerable<Category>>> GetAllAsync()
        {
            var categories = await _context.Categories!.ToListAsync();
            return new Result<IEnumerable<Category>>(categories);
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