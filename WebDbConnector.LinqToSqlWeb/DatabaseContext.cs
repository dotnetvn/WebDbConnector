namespace WebDbConnector.LinqToSqlWeb
{
	using System;
	using System.Collections.Generic;
	using System.Data.Linq;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Web;

	public static class DatabaseContext
	{
		public static TestDataContext GetCurrentContext()
		{
			var context = new WebDbConnectorContext<DataContext>(new LinqToSqlWebDbConnector(new TestDataContext()));
			return context.GetCurrentContext() as TestDataContext;
		}
	}
}