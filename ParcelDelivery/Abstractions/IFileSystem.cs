namespace ParcelDelivery.Abstractions
{
    public interface IFileSystem
    {
        bool FileExists(string filePath);
    }
}