using System;

namespace ParcelDelivery
{
    public struct Attempt<TResult>
    {
        private Attempt(bool success, TResult result, Exception exception)
        {
            Success = success;
            Result = result;
            Exception = exception;
        }

        public bool Success { get; }

        public Exception Exception { get; }

        public TResult Result { get; }

        public static Attempt<TResult> Succeed(TResult result)
        {
            return new Attempt<TResult>(true, result, null);
        }

        public static Attempt<TResult> Fail(TResult result)
        {
            return new Attempt<TResult>(false, result, null);
        }

        public static Attempt<TResult> Fail(TResult result, Exception exception)
        {
            return new Attempt<TResult>(false, result, exception);
        }
    }
}