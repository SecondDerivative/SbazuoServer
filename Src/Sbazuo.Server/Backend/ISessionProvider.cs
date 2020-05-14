namespace Sbazuo.Server.Backend {

	/// <summary>
	/// interface for creating sessions
	/// </summary>
	public interface ISessionProvider {

		/// <summary>
		/// create new session token
		/// </summary>
		/// <returns> session token </returns>
		string CreateSessionToken();

		/// <summary>
		/// validating session token
		/// </summary>
		/// <param name="sessionToken"></param>
		/// <returns> true, if session token is valid </returns>
		bool ValidateSessionToken(string sessionToken);

	}
}
