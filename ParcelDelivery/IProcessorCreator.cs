using ParcelDelivery.Abstractions;

namespace ParcelDelivery
{
    public interface IProcessorCreator<T, TResult> where T : class 
                                                   where TResult : class
    {
        IHandler<T, TResult> Create();
    }
}