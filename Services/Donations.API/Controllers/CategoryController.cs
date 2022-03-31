using Microsoft.AspNetCore.Mvc;

namespace Donations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddCategory()
        {

        }
    }
}
