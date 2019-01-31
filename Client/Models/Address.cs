// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace MeyerCorp.Usps.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Address
    {
        /// <summary>
        /// Initializes a new instance of the Address class.
        /// </summary>
        public Address()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Address class.
        /// </summary>
        public Address(string firmName = default(string), string address1 = default(string), string address2 = default(string), string city = default(string), string cityAbbreviation = default(string), string state = default(string), string zip5 = default(string), string zip4 = default(string), string deliveryPoint = default(string), string carrierRoute = default(string), bool? footnotes = default(bool?), bool? dpvConfirmation = default(bool?), bool? dpvcmra = default(bool?), string dpvFootnotes = default(string), bool? business = default(bool?), bool? centralDeliveryPoint = default(bool?), bool? vacant = default(bool?), string urbanization = default(string), string id = default(string), string error = default(string))
        {
            FirmName = firmName;
            Address1 = address1;
            Address2 = address2;
            City = city;
            CityAbbreviation = cityAbbreviation;
            State = state;
            Zip5 = zip5;
            Zip4 = zip4;
            DeliveryPoint = deliveryPoint;
            CarrierRoute = carrierRoute;
            Footnotes = footnotes;
            DpvConfirmation = dpvConfirmation;
            Dpvcmra = dpvcmra;
            DpvFootnotes = dpvFootnotes;
            Business = business;
            CentralDeliveryPoint = centralDeliveryPoint;
            Vacant = vacant;
            Urbanization = urbanization;
            Id = id;
            Error = error;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "firmName")]
        public string FirmName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "address1")]
        public string Address1 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "address2")]
        public string Address2 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cityAbbreviation")]
        public string CityAbbreviation { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "zip5")]
        public string Zip5 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "zip4")]
        public string Zip4 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "deliveryPoint")]
        public string DeliveryPoint { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "carrierRoute")]
        public string CarrierRoute { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "footnotes")]
        public bool? Footnotes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dpvConfirmation")]
        public bool? DpvConfirmation { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dpvcmra")]
        public bool? Dpvcmra { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dpvFootnotes")]
        public string DpvFootnotes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "business")]
        public bool? Business { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "centralDeliveryPoint")]
        public bool? CentralDeliveryPoint { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "vacant")]
        public bool? Vacant { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "urbanization")]
        public string Urbanization { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

    }
}