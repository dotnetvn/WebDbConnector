namespace WebDbConnector
{
	/// <summary>
	/// This interface defines only one connection to the database per Http Request
	/// </summary>
	/// <typeparam name="TContext">database type</typeparam>
    public interface IWebDbConnector<out TContext> where TContext: class
    {
		/// <summary>
		/// This property is to specify the unique key for storing the database context per request.
		/// </summary>
		string ContextKey { get; }

		/// <summary>
		/// Get the current one connection context to the database per request
		/// </summary>
		/// <returns>Return the database context</returns>
	    TContext GetCurrentContext();
    }
}