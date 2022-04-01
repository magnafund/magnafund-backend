using ModelLibrary;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Donations.API.Services
{
    public class FileService : IFileService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;

        public FileService(IHttpClientFactory httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<Result<FileResponse>> UploadFileAsync(IFormFile file)
        {
            var client = _httpClient.CreateClient("CF-Donations-API");
            HttpRequestMessage message = new();
     
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            message.RequestUri = new Uri(_configuration["Urls:FileServer"]);
            client.DefaultRequestHeaders.Clear();
            var bytes = memoryStream.ToArray();
   
            var form = new MultipartFormDataContent();
            var content = new StreamContent(new MemoryStream(bytes));
            form.Add(content, "file", file.FileName);

            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "file",
                FileName = file.FileName
            };
            content.Headers.Remove("Content-Type");
            content.Headers.Add("Content-Type", "multipart/form-data");
            form.Add(content);
            message.Content = form;
            message.Method = HttpMethod.Post;
            
            var apiResponse = await client.SendAsync(message); 
            var apiContent = await apiResponse.Content.ReadAsStringAsync();
            var apiResponseDto = JsonConvert.DeserializeObject<Result<FileResponse>>(apiContent);
            
            return apiResponseDto!;
        }
    }
}