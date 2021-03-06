﻿using System.Xml.Linq;

namespace MeyerCorp.Usps.Core.Models
{
    public class CityState : Model
    {
        public string Zip5 { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public static CityState Parse(XElement element)
        {
            return new CityState
            {
                City = element.Element("City")?.Value,
                //Error = Error.Parse(element.Element("Error")),
                Zip5 = element.Element("Zip5")?.Value,
                State = element.Element("State")?.Value,
                Id = element.Element("ID")?.Value,
            };
        }
    }
}
