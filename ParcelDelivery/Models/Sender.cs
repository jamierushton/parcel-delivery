namespace ParcelDelivery
{
    public partial class Sender
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}