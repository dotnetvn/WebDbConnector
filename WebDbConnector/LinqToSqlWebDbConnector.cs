namespace WebDbConnector
{
	using System.Data.Linq;
	using System.Web;

	/// <summary>
	/// This class implements one connection to SQL Server database for per Http Request using Linq To Sql ORM Framework.
	/// </summary>
	public class LinqToSqlWebDbConnector : IWebDbConnector<DataContext>
	{
		/// <summary>
		/// Gets and sets the data context.
		/// </summary>
		private readonly DataContext _dataContext;

		/// <summary>
		/// Gets or sets the context key.
		/// </summary>
		private readonly string _contextKey = "linqtosql-key";

		/// <summary>
		/// Initializes a new instance of the <see cref="T:WebDbConnector.LinqToSqlWebDbConnector"/> class by the specified data context.
		/// </summary>
		/// <param name="dataContext">database context</param>
		public LinqToSqlWebDbConnector(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:WebDbConnector.LinqToSqlWebDbConnector"/> class by the specified data context and context key.
		/// </summary>
		/// <param name="dataContext">database context</param>
		/// <param name="contextKey">the unique key for storing the database context per request</param>
		public LinqToSqlWebDbConnector(DataContext dataContext, string contextKey)
			: this(dataContext)
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
		/// <returns>Return the SQL Server DataContext database context</returns>
		public DataContext GetCurrentContext()
		{
			if (HttpContext.Current.Items[ContextKey] == null)
			{
				HttpContext.Current.Items[ContextKey] = _dataContext;
			}
			return HttpContext.Current.Items[ContextKey] as DataContext;
		}
	}
}