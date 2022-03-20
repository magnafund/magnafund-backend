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
    [Route("api/[controller]")]
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

            return Ok(result);
        }
    }
}