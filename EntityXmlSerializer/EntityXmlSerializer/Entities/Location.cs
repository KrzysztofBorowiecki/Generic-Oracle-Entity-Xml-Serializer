using System.Collections.Generic;
using System.Xml.Serialization;

#nullable disable

namespace EntityXmlSerializer.Entities
{
    [XmlType("Location")]
    public partial class Location
    {
        public decimal LocationId { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Department> Departments { get; set; }

        public Location() { }
    }
}
