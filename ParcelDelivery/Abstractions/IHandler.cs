namespace ParcelDelivery.Abstractions
{
    public interface IHandler<T, TResult> where T : class 
                                          where TResult : class
    {
        IHandler<T, TResult> SetNext(IHandler<T, TResult> handler);
        
        Attempt<TResult> Handle(T obj);
    }
}