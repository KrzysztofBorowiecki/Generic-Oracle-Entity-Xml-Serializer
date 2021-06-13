## About Project

EntityXmlSerializer is a generic xml serializer/deserializer base on oracle databases. With this app, you can export data from each table to Xml file, and then you can change some values in Xml file and import these changes to your database.

For this project, I scaffold/use a database from https://www.sqltutorial.org/sql-sample-database/..
> According to the licenses, I use this database for educational purposes.

I tested this app in another three various databases, and I think it would work with each database.

<br />


## Used Technology


- .NET 5.0
- C# 9.0
- EntityFramework 6.4.4
- Microsoft.EntityFrameworkCore.Design 5.0.7
- Microsoft.EntityFrameworkCore.Tools 5.0.7
- Microsoft.Extensions.DependencyInjection 5.0.1
- Mono.Options 6.6.0.161
- Oracle.EntityFrameworkCore 5.21.1





<br />


<br />

### Configuration

If you want to scafold your data-base use this command:

`Scaffold-DbContext "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.145)(PORT=1522)))(CONNECT_DATA=(SID=orcltp)));User ID=s9999;Password=s9999"    Oracle.EntityFrameworkCore`

All you have to do is change your address, user ID, and password.

Then you have to change calls of SerializeXml, DeserializeDataFromXml, UpdateDb methods.

The last step is to prepare each entity class like in the project.
So you have to add decorators: 

- `[XmlType("Country")]` (this example is for Country entity)
- `[XmlIgnore]` 

And add a public constructor without parameters. 


### Usage:

#### You can add parametr / flags into debug section at app properies ####
![alt text](https://github.com/KrzysztofBorowiecki/Generic-Oracle-Entity-Xml-Serializer/blob/main/Docs/VisualStudioDebug.JPG)

#### Console export output ####
![alt text](https://github.com/KrzysztofBorowiecki/Generic-Oracle-Entity-Xml-Serializer/blob/main/Docs/ExportConsoleOutput.JPG)

#### Every entity is saved in separate Xml file ####
![alt text](https://github.com/KrzysztofBorowiecki/Generic-Oracle-Entity-Xml-Serializer/blob/main/Docs/SerializedFolderAfterExport.JPG)

#### Lets change Argentina to Poland #### 
![alt text](https://github.com/KrzysztofBorowiecki/Generic-Oracle-Entity-Xml-Serializer/blob/main/Docs/ModifyCountryXmlFile.JPG)

#### You can use app from console. Now I use import flag below and add changes to data-base ####
![alt text](https://github.com/KrzysztofBorowiecki/Generic-Oracle-Entity-Xml-Serializer/blob/main/Docs/ConsoleImportCommand.JPG)

#### Data-base after import ####
![alt text](https://github.com/KrzysztofBorowiecki/Generic-Oracle-Entity-Xml-Serializer/blob/main/Docs/TableAfterImport.JPG)



<br />
<br />
<br />

### License

MIT
