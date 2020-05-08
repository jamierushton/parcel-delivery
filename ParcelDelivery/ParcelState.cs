using System;

namespace ParcelDelivery
{
    [Flags]
    public enum ParcelState
    {
        None = 0,
        NotSent = 1,
        NeedsApproval = 2,
        Sent = 4
    }
}