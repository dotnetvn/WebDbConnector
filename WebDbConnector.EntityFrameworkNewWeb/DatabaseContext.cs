namespace WebDbConnector.EntityFrameworkNewWeb
{
	using EfNewWebDbConnector;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Data.Objects;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Web;

	public static class DatabaseContext
	{
		public static TestEntities GetCurrentContext()
		{
			var context = new WebDbConnectorContext<DbContext>(new EntityFrameworkNewWebDbConnector(new TestEntities()));
			return context.GetCurrentContext() as TestEntities;
		}
	}
}