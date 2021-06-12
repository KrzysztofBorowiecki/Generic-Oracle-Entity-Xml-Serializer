using EntityXmlSerializer.Entities;
using EntityXmlSerializer.Data;
using EntityXmlSerializer.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace EntityXmlSerializer.Tools
{
    class Exporter
    {
        private readonly ModelContext _context;
        public Exporter(ModelContext context)
        {
            _context = context;
        }

        public void Invoke()
        {
            Console.WriteLine("Read data from Data base tables...\n");
            GetDataFromEntities();

            Console.WriteLine("\nSerializinging Xml file...");

            Console.WriteLine("\nSerializing to Xml done.");
        }

        private void GetDataFromEntities()
        {
            SerializeXml<Country>(_context.Countries.ToList());
            SerializeXml<Department>(_context.Departments.ToList());
            SerializeXml<Dependent>(_context.Dependents.ToList());
            SerializeXml<Employee>(_context.Employees.ToList());
            SerializeXml<Job>(_context.Jobs.ToList());
            SerializeXml<Location>(_context.Locations.ToList());
            SerializeXml<Region>(_context.Regions.ToList());
        }

        private void SerializeXml<T>(List<T> tableRows)
        {
            XmlSerializer serializer = new XmlSerializer(tableRows.GetType());
            TextWriter writer = new StreamWriter($"{InputParameters.XmlDirectoryPath}/Serialized{tableRows[0].GetType().Name}Table.xml");

            serializer.Serialize(writer, tableRows);
            writer.Close();
        }
    }
}
