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

        public async Task<Result<Category>> GetByIdAsync(int id)
        {
            var category = await _context.Categories!.SingleOrDefaultAsync(x => x.Id == id);
            return new Result<Category>(category!);
        }

        public async Task<Result<Category>> UpdateAsync(Category category)
        {
            try
            {
                var categoryObject = (await GetByIdAsync(category.Id)).Data;

                categoryObject!.CategoryName = category.CategoryName;
                categoryObject!.DateModified = category.DateModified;

                _context.Categories!.Update(categoryObject);
                await _context.SaveChangesAsync();

                return new Result<Category>(category);
            }
            catch (Exception)
            {
                return new Result<Category>(false, new List<string> { "Failed to update category! Try again" });
            }
        }
    }
}