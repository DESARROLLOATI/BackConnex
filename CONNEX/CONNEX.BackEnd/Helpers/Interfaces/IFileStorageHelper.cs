namespace CONNEX.ClassLibraries.Interfaces
{
    public interface IFileStorageHelper
    {
        Task<string> SaveFileAsync(byte[] content, string extention, string containerName);

        Task SaveFileByNameAsync(byte[] content, string containerName, string fileName);

        Task<string> SaveFileByNameAndExtensionAsync(byte[] content, string containerName, string fileName, string extension);

        Task RemoveFileAsync(string path, string containerName);

        async Task<string> EditFileAsync(byte[] content, string extention, string containerName, string path)
        {
            if (path is not null)
            {
                await RemoveFileAsync(path, containerName);
            }

            return await SaveFileAsync(content, extention, containerName);
        }
    }
}