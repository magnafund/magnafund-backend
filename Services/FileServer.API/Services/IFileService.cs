using ModelLibrary;

namespace FileServer.API.Services
{
    public interface IFileService
    {
        Task<Result<FileResponse>> UploadFileAsync(IFormFile formFile);
    }
}