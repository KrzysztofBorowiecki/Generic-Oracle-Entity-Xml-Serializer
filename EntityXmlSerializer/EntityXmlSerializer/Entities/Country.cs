using System.Collections.Generic;
using System.Xml.Serialization;

#nullable disable

namespace EntityXmlSerializer
{
    [XmlType("Country")]
    public partial class Country
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public decimal RegionId { get; set; }

        [XmlIgnore]
        public virtual Region Region { get; set; }
        [XmlIgnore]
        public virtual ICollection<Location> Locations { get; set; }

        public Country() { }
    }
}
