namespace Sbazuo.Server.Backend {

	/// <summary>
	/// interface for services, which can register and login accounts
	/// </summary>
	public interface IAccountService {

		/// <summary>
		/// registering new account
		/// </summary>
		/// <param name="nickname"> account nickname </param>
		/// <param name="password"> account password </param>
		/// <returns> account id or null, if registration failed </returns>
		string RegisterAccount(string nickname, string password);

		/// <summary>
		/// check information about account
		/// </summary>
		/// <param name="nickname"> account nickname </param>
		/// <param name="password"> account password </param>
		/// <returns> account id or null, if login failed </returns>
		string Login(string nickname, string password);

	}
}
