namespace WebDbConnector
{
	using System;
	using System.Web;

	/// <summary>
	/// This class will serve as the wrapper for all WebDbConnector implementations
	/// Use it to change any connection type...
	/// </summary>
	/// <typeparam name="T">class type</typeparam>
	public class WebDbConnectorContext<T> where T: class
	{
		/// <summary>
		/// Gets or sets the IWebDbConnector field.
		/// </summary>
		private readonly IWebDbConnector<T> _iWebDbConnector;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:WebDbConnector.WebDbConnectorContext"/> class by the specified WebDbConnector implementation object.
		/// </summary>
		/// <param name="webDbConnector">WebDbConnector implementation object</param>
		public WebDbConnectorContext(IWebDbConnector<T> webDbConnector)
			: this(webDbConnector, WebDbConnectorOptions.WrapperContextKey)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:WebDbConnector.WebDbConnectorContext"/> class by the specified WebDbConnector implementation object.
		/// </summary>
		/// <param name="webDbConnector">WebDbConnector implementation object</param>
		/// <param name="wrapperContextKey">wrapper context key to specify the WebDbConnectorContext per request</param>
		public WebDbConnectorContext(IWebDbConnector<T> webDbConnector, string wrapperContextKey)
		{
			_iWebDbConnector = webDbConnector;
			if (wrapperContextKey != null && WebDbConnectorOptions.WrapperContextKey != wrapperContextKey)
			{
				WebDbConnectorOptions.WrapperContextKey = wrapperContextKey;
			}
			HttpContext.Current.Items[WebDbConnectorOptions.WrapperContextKey] = this;
		}

		/// <summary>
		/// Get the current one connection context to the database per request
		/// </summary>
		/// <returns>Return the T database context</returns>
		public T GetCurrentContext()
		{
			return _iWebDbConnector.GetCurrentContext();
		}

		/// <summary>
		/// Dispose all the resources and close the connection per request
		/// </summary>
		public void Dispose()
		{
			var disposable = _iWebDbConnector as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}
}