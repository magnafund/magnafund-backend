using ModelLibrary;

namespace Donations.API.Services
{
    public interface IFileService
    {
        Task<Result<FileResponse>> UploadFileAsync(IFormFile file);
    }
}