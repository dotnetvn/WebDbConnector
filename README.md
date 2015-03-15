# WebDbConnector
The WebDbConnector is a .NET library used to create and maintain only an unique connection to the database per request in the Asp.Net web applications.

![Class Diagram of the WebDbConnector Library](http://i.imgur.com/7bsLkuH.png "Class Diagram of the WebDbConnector Library")

### Install and Requirements
In order to use this library, your application needs to meet these following criterias:
* Use for the web applications.
* Require the .NET Framework 4.0 or higher.

If okay, then you can install it directly via following ways:
* Via Nuget: ``` Install-Package WebDbConnector ```
* Via Github: ``` git clone https://github.com/congdongdotnet/WebDbConnector.git ```

### Samples
In order to use the WebDbConnector for the ADO.Net SqlConnection, you should create a new class called __DatabaseContext__. In this class, there is a method named __GetCurrentContext__ to get the current context for your connection:
```c#
using System;
using System.Data.SqlClient;
using WebDbConnector;
                    
public static class DatabaseContext
{
    public static SqlConnection GetCurrentContext()
    {
        // The first parameter of SqlWebDbConnector is connection string
        // or connection string name(in Web.config)
        var context = new WebDbConnectorContext<SqlConnection>(
            new SqlWebDbConnector("Test", true));
        return context.GetCurrentContext();
    }
}
```
For ADO.Net SqlConnection, we need to close and dipose all resources related to the SqlConnection when ending the request. You only inherit from WebDbConnectorHttpApplication
```c#
public class Global : WebDbConnectorHttpApplication
{
}
```
Use the WebDbConnector for the Linq To Sql DataContext, we also create the DatabaseContext class as SqlConnection Ado.Net:
```c#
using System;
using System.Data.Linq;
using WebDbConnector;
                    
public static class DatabaseContext
{
    public static DataContext GetCurrentContext()
    {
        var context = new WebDbConnectorContext<DataContext>(
            new LinqToSqlWebDbConnector(new TestDataContext()));
        return context.GetCurrentContext() as TestDataContext;
    }
}
```
Use the WebDbConnector for the Entity Framework ObjectContext, we also create the DatabaseContext class as SqlConnection Ado.Net:
```c#
using System;
using System.Data.Objects;
using WebDbConnector;
                    
public static class DatabaseContext
{
    public static ObjectContext GetCurrentContext()
    {
        var context = new WebDbConnectorContext<ObjectContext>(
                new EntityFrameworkOldWebDbConnector(new TestEntities()));
        return context.GetCurrentContext() as TestEntities;
    }
}
```
Use the WebDbConnector for the Entity Framework DbContext, we also create the DatabaseContext class as SqlConnection Ado.Net:
```c#
using System;
using System.Data.Entity;
using WebDbConnector;
                    
public static class DatabaseContext
{
    public static DbContext GetCurrentContext()
    {
        var context = new WebDbConnectorContext<DbContext>(
                new EntityFrameworkNewWebDbConnector(new TestEntities()));
        return context.GetCurrentContext() as TestEntities;
    }
}
```

### Copyright and License
Copyright 2015 by CongDongDotNet - MIT License
