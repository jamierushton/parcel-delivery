namespace ParcelDelivery
{
    public interface IApprovalProvider
    {
        bool RequestApproval(Parcel parcel);
    }
}