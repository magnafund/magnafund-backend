using Donations.API.Models;
using Donations.API.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [ProducesResponseType(typeof(IEnumerable<Donation>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var donations = await _donationRepository.GetAllAsync();
            return Ok(donations);
        }
    }
}