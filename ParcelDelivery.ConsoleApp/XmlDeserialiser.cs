using System.IO;
using System.Xml.Serialization;
using ParcelDelivery.Abstractions;

namespace ParcelDelivery.ConsoleApp
{
    public sealed class XmlDeserialiser : IDeserialiser
    {
        public T Deserialise<T>(string filePath) where T : class
        {
            XmlSerializer serialiser = new XmlSerializer(typeof(T));
            using FileStream fileStream = new FileStream(filePath, FileMode.Open);
            return (T) serialiser.Deserialize(fileStream);
        }
    }
}