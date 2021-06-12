using System.Collections.Generic;
using System.Xml.Serialization;

#nullable disable

namespace EntityXmlSerializer.Entities
{
    [XmlType("Region")]
    public partial class Region
    {
        public decimal RegionId { get; set; }
        public string RegionName { get; set; }

        public virtual ICollection<Country> Countries { get; set; }

        public Region() { }
    }
}
