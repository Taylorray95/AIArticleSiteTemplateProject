using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace AIArticleSiteTemplateProject.Services
{
    public class BlobServiceClientWrapper
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobServiceClientWrapper(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AzureBlobStorage");
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public BlobContainerClient GetBlobContainerClient(string containerName)
        {
            return _blobServiceClient.GetBlobContainerClient(containerName);
        }

        // Add additional methods here as needed to interact with Blob Storage
    }
}
