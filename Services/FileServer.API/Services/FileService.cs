using ModelLibrary;

namespace FileServer.API.Services
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _configuration;

        public FileService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Result<FileResponse>> UploadFileAsync(IFormFile file)
        {
            try
            {
                string basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Files\\");
                string fileName = Path.GetFileName(file.FileName);
                string newFileName = string.Concat($"cf-{DateTime.Now.Ticks}", fileName);
                string filePath = string.Concat($"{basePath}", newFileName);

                string url = $"{_configuration["Urls:LiveBaseUrl"]}/Files/{newFileName}";
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return new Result<FileResponse>(new FileResponse
                {
                    FileName = newFileName,
                    Url = url,
                    Path = filePath
                });
            }
            catch (Exception ex)
            {
                return new Result<FileResponse>(false, new List<string> { ex.ToString() });
            }
        }

    }
}