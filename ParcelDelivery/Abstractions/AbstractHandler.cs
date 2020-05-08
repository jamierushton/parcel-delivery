namespace ParcelDelivery.Abstractions
{
    public abstract class AbstractHandler<T, TResult> : IHandler<T, TResult> where T : class 
                                                                             where TResult : class
    {
        private IHandler<T, TResult> _nextHandler;

        public IHandler<T, TResult> SetNext(IHandler<T, TResult> handler)
        {
            _nextHandler = handler;

            return handler;
        }

        public virtual Attempt<TResult> Handle(T obj)
        {
            return _nextHandler?.Handle(obj) ?? throw new NoSuitableHandlerException();
        }
    }
}