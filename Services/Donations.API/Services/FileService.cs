using ModelLibrary;

namespace Donations.API.Services
{
    public class FileService : IFileService
    {
        private readonly HttpClient _httpClient;

        public FileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Result<FileResponse>> UploadFileAsync(IFormFile file)
        {
            return null;
        }
    }
}