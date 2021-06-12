## About Project

EntityXmlSerializer is a generic xml serializer/deserializer base on oracle data-bases. With this app you can export data from each table to xml files, then you can change some values in xml and import this changes to your database.

For this project I scafold/use data-base from https://www.sqltutorial.org/sql-sample-database/.
> According to the licenses, I use it database for educational purposes.
I tested also this app in another 3 diffrent data-base and I think it would work with each data-base.

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

All what you have to do is change your address, user id and password.

Then you have to change calls of SerializeXml, DeserializeDataFromXml, UpdateDb methods

Last step is prepare each entity class like in project.
So you have to add decorators: 

- `[XmlType("Country")]` (this example is for Country entity)
- `[XmlIgnore]` 

and public constructor without parameters 


### Usage:




<br />
<br />
<br />

### License

MIT
