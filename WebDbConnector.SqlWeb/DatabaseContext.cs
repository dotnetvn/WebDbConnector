namespace WebDbConnector.SqlWeb
{
	using SqlAdoWebDbConnector;
	using System;
	using System.Collections.Generic;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Web;

	public static class DatabaseContext
	{
		public static SqlConnection GetCurrentContext()
		{
			var context = new WebDbConnectorContext<SqlConnection>(new SqlWebDbConnector("Test", true));
			return context.GetCurrentContext();
		}
	}
}