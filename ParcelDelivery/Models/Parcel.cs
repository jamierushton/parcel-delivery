using System.Xml.Serialization;

namespace ParcelDelivery
{
    public partial class Parcel
    {
        public Parcel()
        {
            
        }

        [XmlElement(typeof(Sender))]
        [XmlElement(typeof(Company))]
        public Sender Sender { get; set; }
        public Receipient Receipient { get; set; }
        public float Weight { get; set; }
        public float Value { get; set; }
    }
}