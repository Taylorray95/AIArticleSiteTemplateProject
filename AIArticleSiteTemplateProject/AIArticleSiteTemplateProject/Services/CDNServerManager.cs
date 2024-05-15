using Microsoft.Extensions.Options;
using System.Net;
using System.IO;
using AIArticleSiteTemplateProject.Models;

namespace AIArticleSiteTemplateProject.Services
{
    public class CDNServerManager(IOptions<CDNCredentials> credentials)
    {

        private readonly CDNCredentials _credentials = credentials.Value;

        public string GetNetworkShareBasePath(string folderType)
        {
            string folderPath = folderType == "ProfilePhotos" ? _credentials.ProfilePhotoFolder! : _credentials.PostImagesFolder!;
            return $"\\\\{_credentials.CDNServer}\\{_credentials.ApplicationName}\\{folderPath}";
        }

        // Method to build the base URL for images
        public string GetBaseImageUrl(string folderType)
        {
            string folderPath = folderType == "ProfilePhotos" ? _credentials.ProfilePhotoFolder! : _credentials.PostImagesFolder!;
            return $"https://{_credentials.CDNLink}:{_credentials.CDNPort}/{folderPath}/";
        }

        //public string GetImageUrl(string baseUrl, string ID)
        //{
        //    return $"{baseUrl}{ID}";
        //}

        public string GetItemNetworkPath(string basePath, string ID)
        {
            return $"{basePath}\\{ID}";
        }

        public string GetFullImageUrl(string folderType, string fileName)
        {
            return GetBaseImageUrl(folderType) + fileName;
        }

        public string GetFullSharePath(string folderType, string fileName)
        {
            return Path.Combine(GetNetworkShareBasePath(folderType), fileName);
        }

        // Method to upload an image file to the network share
        //public async Task UploadImageAsync(string folderType, byte[] imageContent, string fileName)
        //{
        //    string basePath = GetNetworkShareBasePath(folderType);
        //    string fullPath = Path.Combine(basePath, fileName);

        //    using (var networkConnection = new NetworkConnection(basePath, new NetworkCredential(_credentials.CDNServiceAccount, _credentials.CDNServicePassword, _credentials.CDNServer)))
        //    {
        //        using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
        //        {
        //            await fileStream.WriteAsync(imageContent, 0, imageContent.Length);
        //        }
        //    }
        //}

        //public async Task<string> UploadImageAsync(string folderType, byte[] imageContent, bool useUUID)
        //{
        //    string fileName = useUUID ? Guid.NewGuid().ToString() + ".png" : "default.png";
        //    string basePath = GetNetworkShareBasePath(folderType);
        //    string fullPath = Path.Combine(basePath, fileName);

        //    using (var networkConnection = new NetworkConnection(fullPath, new NetworkCredential(_credentials.CDNServiceAccount, _credentials.CDNServicePassword, _credentials.CDNServer)))
        //    {
        //        using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
        //        {
        //            await fileStream.WriteAsync(imageContent, 0, imageContent.Length);
        //        }
        //    }
        //    return fileName;  // Return the file name (UUID or default) used
        //}

        public async Task<string> UploadImageAsync(string folderType, byte[] imageContent, bool useUUID)
        {
            string fileName = useUUID ? Guid.NewGuid().ToString() + ".png" : "default.png";
            string basePath = GetNetworkShareBasePath(folderType);
            string fullPath = Path.Combine(basePath, fileName);

            // Ensure the connection is made to the base path, not the full path
            using (var networkConnection = new NetworkConnection(basePath, new NetworkCredential(_credentials.CDNServiceAccount, _credentials.CDNServicePassword, _credentials.CDNServer)))
            {
                using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
                {
                    await fileStream.WriteAsync(imageContent, 0, imageContent.Length);
                }
            }
            return fileName;  // Return the file name (UUID or default) used
        }

        // Method to delete an image file from the network share
        public async Task DeleteImageAsync(string folderType, string ID)
        {
            string basePath = GetNetworkShareBasePath(folderType);
            string fullPath = GetItemNetworkPath(basePath, ID);

            int maxRetries = 5;
            int delay = 1000;  // Delay in milliseconds

            for (int i = 0; i < maxRetries; i++)
            {
                try
                {
                    if (File.Exists(fullPath))
                    {
                        File.Delete(fullPath);
                        break;  // If delete is successful, break out of the loop
                    }
                }
                catch (IOException)
                {
                    if (i < maxRetries - 1)  // Wait only if we are retrying
                    {
                        await Task.Delay(delay);  // Asynchronously wait for the file to become free
                    }
                    else
                    {
                        throw new IOException($"Unable to delete file after {maxRetries} attempts.");
                    }
                }
                catch (Exception ex)
                {
                    // Handle other types of exceptions if necessary
                    throw new Exception($"Failed to delete file: {ex.Message}");
                }
            }
        }
    }
}
