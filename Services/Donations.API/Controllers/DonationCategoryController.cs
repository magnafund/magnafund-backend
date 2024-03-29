﻿using Donations.API.Models;
using Donations.API.Models.Data;
using Donations.API.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Donations.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DonationCategoryController : ControllerBase
    {
        private readonly IDonationCategoryRepository _donationCategoryRepository;

        public DonationCategoryController(IDonationCategoryRepository donationCategoryRepository) => _donationCategoryRepository = donationCategoryRepository;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _donationCategoryRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _donationCategoryRepository.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("add-category")]
        public async Task<IActionResult> AddCategory(CategoryRequest request)
        {
            var result = await _donationCategoryRepository.AddAsync(new Category
            {
                CategoryName = request.CategoryName,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
            });

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("update-category")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryRequest request)
        {
            var result = await _donationCategoryRepository.UpdateAsync(new Category
            {
                Id = request.Id,
                CategoryName = request?.CategoryName,
                DateModified = DateTime.Now
            });

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}