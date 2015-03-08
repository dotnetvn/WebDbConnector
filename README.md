# WebDbConnector
The WebDbConnector is a .NET library used to create and maintain only an unique connection to the database per request in the Asp.Net web applications.

### Install and Requirements
In order to use this library, your application needs to meet these following criterias:
* Use for the web applications.
* Require the .NET Framework 4.0 or higher.

If okay, then you can install it directly via following ways:
* Via Nuget: ``` Install-Package WebDbConnector ```
* Via Github: ``` git clone https://github.com/congdongdotnet/WebDbConnector/WebDbConnector.git ```

### Samples
Use the WebDbConnector for the ADO.Net SqlConnection:
```c#
// The first parameter of SqlWebDbConnector is connection string or connection string name(in Web.config)
var context = new WebDbConnectorContext<SqlConnection>(new SqlWebDbConnector("Test", true));
var sqlContext = context.GetCurrentContext();
// TODO: write your own code
```
Use the WebDbConnector for the Linq To Sql DataContext:
```c#
var context = new WebDbConnectorContext<DataContext>(new LinqToSqlWebDbConnector(new TestDataContext()));
var dataContext = context.GetCurrentContext() as TestDataContext;
// TODO: write your own code
```
Use the WebDbConnector for the Entity Framework DbContext:
```c#
var context = new WebDbConnectorContext<DbContext>(new EntityFrameworkNewWebDbConnector(new TestEntities()));
var dbContext = context.GetCurrentContext() as TestEntities;
// TODO: write your own code
```

### Copyright and License
Copyright 2015 by CongDongDotNet - MIT License
