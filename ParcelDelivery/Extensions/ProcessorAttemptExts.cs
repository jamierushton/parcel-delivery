namespace ParcelDelivery.Extensions
{
    public static class ProcessorAttemptExts
    {
        public static (ParcelState, ProcessorResult) GetParcelState(this Attempt<ProcessorResult> attempt)
        {
            if (attempt.Exception != null)
                return (ParcelState.NotSent, null);

            var result = attempt.Result;

            return result.RequiresApproval ? (ParcelState.NeedsApproval, result) : (ParcelState.Sent, result);
        }
    }
}