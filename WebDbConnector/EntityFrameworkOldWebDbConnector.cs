namespace WebDbConnector
{
	using System.Data.Objects;
	using System.Web;

	/// <summary>
	/// This class implements one connection to any database for per Http Request using Entity Framework ObjectContext.
	/// </summary>
	public class EntityFrameworkOldWebDbConnector : IWebDbConnector<ObjectContext>
	{
		/// <summary>
		/// Gets or sets the object context.
		/// </summary>
		private readonly ObjectContext _objectContext;

		/// <summary>
		/// Gets or sets the context key.
		/// </summary>
		private readonly string _contextKey = "efold-key";

		/// <summary>
		/// Initializes a new instance of the <see cref="T:WebDbConnector.EntityFrameworkOldWebDbConnector"/> class by the specified object context.
		/// </summary>
		/// <param name="objectContext">object context</param>
		public EntityFrameworkOldWebDbConnector(ObjectContext objectContext)
		{
			_objectContext = objectContext;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:WebDbConnector.EntityFrameworkOldWebDbConnector"/> class by the specified object context and context key.
		/// </summary>
		/// <param name="objectContext">object context</param>
		/// <param name="contextKey">the unique key for storing the database context per request</param>
		public EntityFrameworkOldWebDbConnector(ObjectContext objectContext, string contextKey)
			: this(objectContext)
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
		/// Get the current one connection context to any database per request
		/// </summary>
		/// <returns>Return the ObjectContext database context</returns>
		public ObjectContext GetCurrentContext()
		{
			if (HttpContext.Current.Items[ContextKey] == null)
			{
				HttpContext.Current.Items[ContextKey] = _objectContext;
			}
			return HttpContext.Current.Items[ContextKey] as ObjectContext;
		}
	}
}