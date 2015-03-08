using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDbConnector.EntityFrameworkNewWeb
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				var dbContext = DatabaseContext.GetCurrentContext();
				if (dbContext != null)
				{
					gv.DataSource = dbContext.Messages.ToList();
					gv.DataBind();
				}
			}
		}
	}
}