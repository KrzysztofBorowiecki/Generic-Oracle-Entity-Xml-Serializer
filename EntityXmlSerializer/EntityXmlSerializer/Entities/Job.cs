using System.Collections.Generic;
using System.Xml.Serialization;

#nullable disable

namespace EntityXmlSerializer.Entities
{
    [XmlType("Job")]
    public partial class Job
    {
        public decimal JobId { get; set; }
        public string JobTitle { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }

        [XmlIgnore]
        public virtual ICollection<Employee> Employees { get; set; }

        public Job() { }
    }
}
