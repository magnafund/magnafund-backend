using Microsoft.AspNetCore.Mvc;

namespace FileServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {

        [HttpPost("upload-file")]
        public async Task UploadFileAsync(IFormFile file)
        {

        }
    }
}