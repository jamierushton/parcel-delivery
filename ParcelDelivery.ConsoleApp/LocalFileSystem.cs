using System.IO;
using ParcelDelivery.Abstractions;

namespace ParcelDelivery.ConsoleApp
{
    public sealed class LocalFileSystem : IFileSystem
    {
        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}