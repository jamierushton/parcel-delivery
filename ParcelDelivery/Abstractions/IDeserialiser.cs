namespace ParcelDelivery.Abstractions
{
    public interface IDeserialiser
    {
        T Deserialise<T>(string filePath) where T : class;
    }
}