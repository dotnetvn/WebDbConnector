namespace WebDbConnector.SqlWeb
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Security;
	using System.Web.SessionState;
	using WebDbConnector;

	public class Global : WebDbConnectorHttpApplication
	{
		protected override void Application_EndRequest(object sender, EventArgs e)
		{
			base.Application_EndRequest(sender, e);
			// TODO: write more own code
		}
	}
}