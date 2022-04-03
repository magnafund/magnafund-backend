using AutoMapper;
using Donations.API.Models.Data;
using Microsoft.EntityFrameworkCore;
using ModelLibrary;

namespace Donations.API.Models.Repository
{
    public class DonationCategoryRepository : IDonationCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DonationCategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task<Result<Category>> UpdateAsync(UpdateCategoryRequest category)
        {
            try
            {
                var categoryInDb = (await GetByIdAsync(category.Id)).Data;

                categoryInDb = _mapper.Map<Category>(category);
                _context.Categories!.Update(categoryInDb);
                await _context.SaveChangesAsync();

                return new Result<Category>(categoryInDb);
            }
            catch (Exception)
            {
                return new Result<Category>(false, new List<string> { "Failed to update category! Try again" });
            }
        }
    }
}