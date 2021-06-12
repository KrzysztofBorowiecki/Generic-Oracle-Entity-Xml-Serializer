using System.Collections.Generic;
using System.Xml.Serialization;

#nullable disable

namespace EntityXmlSerializer.Entities
{
    [XmlType("Department")]
    public partial class Department
    {
        public decimal DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public decimal? LocationId { get; set; }

        [XmlIgnore]
        public virtual Location Location { get; set; }
        [XmlIgnore]
        public virtual ICollection<Employee> Employees { get; set; }

        public Department() { }
    }
}
