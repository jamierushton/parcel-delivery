using System;
using System.IO;
using ParcelDelivery.Abstractions;

namespace ParcelDelivery.ConsoleApp
{
    public class ParcelApplication
    {
        private readonly IDeserialiser _deserialiser;
        private readonly IFileSystem _fileSystem;
        private readonly IParcelProcessor _parcelProcessor;

        public ParcelApplication(IParcelProcessor parcelProcessor,
                                 IDeserialiser deserialiser,
                                 IFileSystem fileSystem)
        {
            _parcelProcessor = parcelProcessor;
            _deserialiser = deserialiser;
            _fileSystem = fileSystem;
        }

        public void ProcessFromFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException(nameof(filePath));

            if (!_fileSystem.FileExists(filePath))
                throw new FileNotFoundException("Cannot start process. Unable to locate file.", filePath);

            var container = _deserialiser.Deserialise<Container>(filePath);

            _parcelProcessor.Process(container);
        }
    }
}