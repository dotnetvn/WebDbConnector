using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDbConnector.LinqToSqlWeb
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				var dataContext = DatabaseContext.GetCurrentContext();
				if (dataContext != null)
				{
					gv.DataSource = dataContext.GetTable<Message>();
					gv.DataBind();
				}
			}
		}
	}
}