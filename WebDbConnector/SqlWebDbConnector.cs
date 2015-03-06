namespace WebDbConnector
{
	using System;
	using System.Configuration;
	using System.Data;
	using System.Data.SqlClient;
	using System.Web;

	/// <summary>
	/// This class implements one connection to SQL Server database for per Http Request using Ado.Net.
	/// </summary>
	public class SqlWebDbConnector : IWebDbConnector<SqlConnection>, IDisposable
	{
		/// <summary>
		/// Gets and sets the connection string to the SQL Server database.
		/// </summary>
		private readonly string _connectionString;

		/// <summary>
		/// Gets or sets the context key.
		/// </summary>
		private readonly string _contextKey = "adonet-sqlconn-key";

		/// <summary>
		/// Gets or sets the flag to check whether all resources has been disposed or not
		/// </summary>
		private bool _disposed;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:WebDbConnector.AdoNetWebDbConnector"/> class by the specified connection string and enable to get the connection string from the configuration file.
		/// </summary>
		/// <param name="connectionString">database connection string</param>
		/// <param name="getInConfig">specify the connection string should be get in the configuration file(app.conf or web.conf)</param>
		public SqlWebDbConnector(string connectionString, bool getInConfig = false)
		{
			if (getInConfig)
			{
				var connectionStringConfig = ConfigurationManager.ConnectionStrings[connectionString];
				if (connectionStringConfig != null)
				{
					_connectionString = connectionStringConfig.ConnectionString;
				}
			}
			else
			{
				_connectionString = connectionString;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:WebDbConnector.AdoNetWebDbConnector"/> class by the specified connection
		/// string, context key and enable to get the connection string from the configuration file.
		/// </summary>
		/// <param name="connectionString">database connection string.</param>
		/// <param name="contextKey">the unique key for storing the SQL Server database context per request.</param>
		/// <param name="getInConfig">specify the connection string should be get in the configuration file(app.config or web.config).</param>
		public SqlWebDbConnector(string connectionString, string contextKey, bool getInConfig = false)
			: this(connectionString, getInConfig)
		{
			_contextKey = contextKey;
		}

		/// <summary>
		/// This property is to specify the unique key for storing the SQL Server database context per request.
		/// </summary>
		public string ContextKey
		{
			get { return _contextKey; }
		}

		/// <summary>
		/// Get the current one connection context to the SQL Server database per request
		/// </summary>
		/// <returns>Return the SQL Server SqlConnection database context</returns>
		public SqlConnection GetCurrentContext()
		{
			// If no exist in the request, create an unique connection to database per Http Request
			if (HttpContext.Current.Items[ContextKey] == null)
			{
				var sqlConnection = new SqlConnection(_connectionString);
				HttpContext.Current.Items[ContextKey] = sqlConnection;
			}

			// Get an unique connection to database from Http context for per request
			var connection = HttpContext.Current.Items[ContextKey] as SqlConnection;
			if (connection != null && connection.State != ConnectionState.Open)
			{
				try
				{
					connection.Open();
				}
				catch
				{
					return null;
				}
			}
			return connection;
		}

		/// <summary>
		/// Dispose all the resources and close the connection per request
		/// </summary>
		/// <returns>Returns true, disposed. Otherwise false, no to be disposed</returns>
		public void Dispose()
		{
			Dispose(true);
		}

		/// <summary>
		/// Dispose all the resources and close the connection per request
		/// </summary>
		/// <param name="disposing">the flag enables to dispose or not</param>
		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
				return;

			if (disposing)
			{
				var sqlConnection = GetCurrentContext();
				if (sqlConnection != null)
				{
					try
					{
						// Calls the Dispose() in SqlConnection
						// It will close the connection as well.
						sqlConnection.Dispose();
					}
					catch
					{
						_disposed = false;
						return;
					}
				}
			}

			_disposed = true;
		}
	}
}