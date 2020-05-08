using System.Xml.Serialization;

namespace ParcelDelivery
{
    public partial class Container
    {
        public string Id { get; set; }
        public string ShippingDate { get; set; }

        [XmlArray(ElementName = "parcels")]
        public Parcel[] Parcels { get; set; }
    }
}