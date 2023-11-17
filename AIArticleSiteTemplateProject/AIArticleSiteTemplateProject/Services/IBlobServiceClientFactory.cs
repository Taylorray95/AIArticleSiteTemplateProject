using Azure.Storage.Blobs;

namespace AIArticleSiteTemplateProject.Services
{
    public interface IBlobServiceClientFactory
    {
        BlobServiceClientWrapper CreateBlobServiceClient();
    }
}
