namespace ParcelDelivery
{
    public partial class Parcel
    {
        public Parcel(Parcel parcel, bool approved)
        {
            Value = parcel.Value;
            Weight = parcel.Weight;
            Sender = parcel.Sender;
            Receipient = parcel.Receipient;
            Approved = approved;
        }

        public bool? Approved { get; set; }
    }
}