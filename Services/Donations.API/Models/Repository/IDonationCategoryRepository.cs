﻿using ModelLibrary;

namespace Donations.API.Models.Repository
{
    public interface IDonationCategoryRepository
    {
        Task<Result<IEnumerable<Category>>> GetAllAsync();
        Task<Result<Category>> GetByIdAsync(int id);
        Task<Result<Category>> AddAsync(Category category);
        Task<Result<Category>> UpdateAsync(Category category);
        Task<Result<bool>> DeleteAsync(int id);
    }
}