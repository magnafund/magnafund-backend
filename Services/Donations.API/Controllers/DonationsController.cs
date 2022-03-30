using Donations.API.Enums;
using Donations.API.Models;
using Donations.API.Models.Data;
using Donations.API.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary;

namespace Donations.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DonationsController : ControllerBase
    {
        private readonly IDonationRepository _donationRepository;

        public DonationsController(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        [HttpGet("get-all-donations")]
        [ProducesResponseType(typeof(Result<IEnumerable<Donation>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var donations = await _donationRepository.GetAllAsync();
            return Ok(donations);
        }

        [HttpGet("get-by-id/{id}")]
        [ProducesResponseType(typeof(Result<Donation>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var donation = await _donationRepository.GetByIdAsync(id);
            return Ok(donation);
        }

        [HttpGet("get-by-userId/{userId}")]
        [Authorize]
        [ProducesResponseType(typeof(Result<IEnumerable<Donation>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var donations = await _donationRepository.GetByUserIdAsync(userId);
            return Ok(donations);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> AddDonation(DonationRequest request)
        {
           var result = await _donationRepository.AddDonationAsync(new Donation
            {
                Description = request.Description,
                AmountGoal = request.AmountGoal,
                AmountRaised = 0,
                DateCreated = DateTime.Now,
                EndDate = request.EndDate,
                Status = DonationStatus.Active,
                UserId = request.UserId
            });

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("update-donation")]
        [Authorize]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateDonation(UpdateDonationRequest request)
        {
            var result = await _donationRepository.UpdateDonationAsync(new Donation
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                AmountGoal = request.AmountGoal,
                EndDate = request.EndDate
            });

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("revoke-donation/{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Result<Donation>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> RevokeDonation(int id)
        {
            var result = await _donationRepository.RevokeDonationAsync(id);
            return Ok(result);
        }
    }
}