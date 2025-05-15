using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CONNEX.BackEnd.Helpers.Interfaces;

namespace CONNEX.BackEnd.Helpers.Implementations
{
    public class FileStorageHelper : IFileStorageHelper
    {
        private readonly string _connectionString;

        public FileStorageHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureStorage")!;
        }

        public async Task RemoveFileAsync(string path, string containerName)
        {
            var client = new BlobContainerClient(_connectionString, containerName);
            await client.CreateIfNotExistsAsync();
            var fileName = Path.GetFileName(path);
            var blob = client.GetBlobClient(fileName);
            await blob.DeleteIfExistsAsync();
        }

        public async Task<string> SaveFileAsync(byte[] content, string extension, string containerName)
        {
            var client = new BlobContainerClient(_connectionString, containerName);
            await client.CreateIfNotExistsAsync();
            client.SetAccessPolicy(PublicAccessType.Blob);
            var fileName = $"{Guid.NewGuid()}{extension}";
            var blob = client.GetBlobClient(fileName);

            var blobHttpHeaders = new BlobHttpHeaders();

            if (extension != null)
            {
                if (extension == ".pdf")
                {
                    blobHttpHeaders.ContentType = "application/pdf";
                }
            }

            using (var ms = new MemoryStream(content))
            {
                await blob.UploadAsync(ms);
            }

            return blob.Uri.ToString();
        }

        public async Task SaveFileByNameAsync(byte[] content, string containerName, string fileName)
        {
            var client = new BlobContainerClient(_connectionString, containerName);
            await client.CreateIfNotExistsAsync();
            client.SetAccessPolicy(PublicAccessType.Blob);
            var blob = client.GetBlobClient(fileName);            

            using (var ms = new MemoryStream(content))
            {
                await blob.UploadAsync(ms);
            }
        }

        public async Task<string> SaveFileByNameAndExtensionAsync(byte[] content, string containerName, string fileName, string extension)
        {
            var client = new BlobContainerClient(_connectionString, containerName);
            await client.CreateIfNotExistsAsync();
            client.SetAccessPolicy(PublicAccessType.Blob);

            var blobFileName = $"{fileName}{extension}";

            var blob = client.GetBlobClient(blobFileName);

            var blobHttpHeaders = new BlobHttpHeaders();

            if (extension != null)
            {
                if (extension == ".xlsx")
                {
                    blobHttpHeaders.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                }
            }

            using (var ms = new MemoryStream(content))
            {
                await blob.UploadAsync(ms, blobHttpHeaders);
            }

            return blob.Uri.ToString();
        }
    }
}
