namespace WebDbConnector
{
	using System.Data.Entity;
	using System.Web;

	/// <summary>
	/// This class implements one connection to any database type for per Http Request using Entity Framework DbContext.
	/// </summary>
	public class EntityFrameworkNewWebDbConnector : IWebDbConnector<DbContext>
	{
		/// <summary>
		/// Gets or sets the db context.
		/// </summary>
		private readonly DbContext _dbContext;

		/// <summary>
		/// Gets or sets the context key.
		/// </summary>
		private readonly string _contextKey = "efnew-key";

		/// <summary>
		/// Initializes a new instance of the <see cref="T:WebDbConnector.EntityFrameworkNewWebDbConnector"/> class by the specified object context.
		/// </summary>
		/// <param name="dbContext">object context</param>
		public EntityFrameworkNewWebDbConnector(DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:WebDbConnector.EntityFrameworkNewWebDbConnector"/> class by the specified object context and context key.
		/// </summary>
		/// <param name="dbContext">object context</param>
		/// <param name="contextKey">the unique key for storing the database context per request</param>
		public EntityFrameworkNewWebDbConnector(DbContext dbContext, string contextKey)
			: this(dbContext)
		{
			_contextKey = contextKey;
		}

		/// <summary>
		/// This property is to specify the unique key for storing the database context per request.
		/// </summary>
		public string ContextKey
		{
			get { return _contextKey; }
		}

		/// <summary>
		/// Get the current one connection context to any database type per request
		/// </summary>
		/// <returns>Return the DbContext database context</returns>
		public DbContext GetCurrentContext()
		{
			if (HttpContext.Current.Items[ContextKey] == null)
			{
				HttpContext.Current.Items[ContextKey] = _dbContext;
			}
			return HttpContext.Current.Items[ContextKey] as DbContext;
		}
	}
}