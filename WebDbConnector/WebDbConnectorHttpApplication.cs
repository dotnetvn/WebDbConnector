namespace WebDbConnector
{
	using System;
	using System.Web;

	/// <summary>
	/// This abstract class implements closing the connection to the database and dispose all resources.
	/// Please override on Application_EndRequest to customize your own.
	/// </summary>
	public abstract class WebDbConnectorHttpApplication : HttpApplication
	{
		/// <summary>
		/// This event will be fired when the request ends.
		/// </summary>
		/// <param name="sender">object Application</param>
		/// <param name="e">Event data</param>
		protected virtual void Application_EndRequest(object sender, EventArgs e)
		{
			var webDbConnectorContext = HttpContext.Current.Items[WebDbConnectorOptions.WrapperContextKey] as WebDbConnectorContext<Object>;
			if (webDbConnectorContext != null)
			{
				webDbConnectorContext.Dispose();
			}
		}
	}
}