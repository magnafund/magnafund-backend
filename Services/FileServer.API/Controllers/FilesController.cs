using FileServer.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService) => _fileService = fileService;

        [HttpPost("upload-file")]
        public async Task<IActionResult> UploadFileAsync(IFormFile file)
        {
            var result = await _fileService.UploadFileAsync(file);
            
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}