using EntityXmlSerializer.Data;
using EntityXmlSerializer.Entities;
using EntityXmlSerializer.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace EntityXmlSerializer.Tools
{
    class Importer
    {
        private readonly ModelContext _context;
        public Importer(ModelContext context)
        {
            _context = context;
        }

        public void Invoke()
        {
            Console.WriteLine("Deseriaizing xml files...\n");
            var countries = DeserializeDataFromXml<Country>($"{InputParameters.XmlDirectoryPath}/SerializedCountryTable.xml");
            var departments = DeserializeDataFromXml<Department>($"{InputParameters.XmlDirectoryPath}/SerializedDepartmentTable.xml");
            var dependents = DeserializeDataFromXml<Dependent>($"{InputParameters.XmlDirectoryPath}/SerializedDependentTable.xml");
            var employees = DeserializeDataFromXml<Employee>($"{InputParameters.XmlDirectoryPath}/SerializedEmployeeTable.xml");
            var jobs = DeserializeDataFromXml<Job>($"{InputParameters.XmlDirectoryPath}/SerializedJobTable.xml");
            var locations = DeserializeDataFromXml<Location>($"{InputParameters.XmlDirectoryPath}/SerializedLocationTable.xml");
            var regions = DeserializeDataFromXml<Region>($"{InputParameters.XmlDirectoryPath}/SerializedRegionTable.xml");

            Console.WriteLine("\nAdd changes to database...");

            UpdateDb<Country>(countries, "CountryId");
            UpdateDb<Department>(departments, "DepartmentId");
            UpdateDb<Dependent>(dependents, "BrandId");
            UpdateDb<Employee>(employees, "CarmodelId");
            UpdateDb<Job>(jobs, "ColourId");
            UpdateDb<Location>(locations, "CountryOfOriginId");
            UpdateDb<Region>(regions, "FuelId");

            Console.WriteLine("Saving changes to database done");
        }

        private List<T> DeserializeDataFromXml<T>(string path)
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = $"ArrayOf{typeof(T).Name}";
            xRoot.IsNullable = true;

            XmlSerializer serializer = new XmlSerializer(typeof(List<T>), xRoot);

            serializer.UnknownNode += new XmlNodeEventHandler(serializer_UnknownNode);
            serializer.UnknownAttribute += new XmlAttributeEventHandler(serializer_UnknownAttribute);

            List<T> type;

            StreamReader reader = new StreamReader(path);
            type = (List<T>)serializer.Deserialize(reader);
            reader.Close();

            return type;
        }

        private void UpdateDb<T>(List<T> list, string idPropertyName)
        where T : class
        {
            Type myType = typeof(T);

            PropertyInfo idProp = myType.GetProperty(idPropertyName);

            foreach (var item in list)
            {
                var id = idProp.GetValue(item);

                var current = _context.Set<T>().Find(id);
                _context.Entry(current).CurrentValues.SetValues(item);
            }

            _context.SaveChanges();
        }

        private void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            Console.WriteLine("Unknown Node:" + e.Name + "\t" + e.Text);
        }

        private void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            System.Xml.XmlAttribute attr = e.Attr;
            Console.WriteLine("Unknown attribute " +
            attr.Name + "='" + attr.Value + "'");
        }
    }
}
