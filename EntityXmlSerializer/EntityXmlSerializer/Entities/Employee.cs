using System;
using System.Collections.Generic;
using System.Xml.Serialization;

#nullable disable

namespace EntityXmlSerializer.Entities
{
    [XmlType("Employee")]
    public partial class Employee
    {
        public decimal EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public decimal JobId { get; set; }
        public decimal Salary { get; set; }
        public decimal? ManagerId { get; set; }
        public decimal? DepartmentId { get; set; }

        [XmlIgnore]
        public virtual Department Department { get; set; }
        [XmlIgnore]
        public virtual Job Job { get; set; }
        [XmlIgnore]
        public virtual Employee Manager { get; set; }
        [XmlIgnore]
        public virtual ICollection<Dependent> Dependents { get; set; }
        [XmlIgnore]
        public virtual ICollection<Employee> InverseManager { get; set; }

        public Employee() { }
    }
}
