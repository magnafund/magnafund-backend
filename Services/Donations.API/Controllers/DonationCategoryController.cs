using Microsoft.AspNetCore.Mvc;

namespace Donations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationCategoryController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddCategory()
        {

        }
    }
}
