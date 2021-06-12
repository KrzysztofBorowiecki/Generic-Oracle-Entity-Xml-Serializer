using System.Xml.Serialization;

#nullable disable

namespace EntityXmlSerializer
{
    [XmlType("Dependent")]
    public partial class Dependent
    {
        public decimal DependentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Relationship { get; set; }
        public decimal EmployeeId { get; set; }

        [XmlIgnore]
        public virtual Employee Employee { get; set; }

        public Dependent() { }
    }
}
