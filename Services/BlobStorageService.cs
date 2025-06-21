
using Azure.Storage.Blobs;

namespace Price_Comparison.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly IConfiguration _config;

        public BlobStorageService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> UploadFileAsync(IFormFile file, string containerName)
        {
            var connectionString = _config["AzureBlob:ConnectionString"];
            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            await containerClient.CreateIfNotExistsAsync();
            var blobClient = containerClient.GetBlobClient(Guid.NewGuid() + Path.GetExtension(file.FileName));

            using var stream = file.OpenReadStream();
            await blobClient.UploadAsync(stream);

            return blobClient.Uri.ToString(); // return public URL
        }
    }
}
