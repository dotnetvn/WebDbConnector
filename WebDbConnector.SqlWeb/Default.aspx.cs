namespace WebDbConnector.SqlWeb
{
	using System;
	using System.Collections.Generic;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				var sqlConnection = DatabaseContext.GetCurrentContext();
				if (sqlConnection != null)
				{
					var sqlCommand = new SqlCommand("SELECT * FROM Message", sqlConnection);
					var sqlReader = sqlCommand.ExecuteReader();
					gv.DataSource = sqlReader;
					gv.DataBind();
					sqlReader.Close();
				}
			}
		}
	}
}