using Sbazuo.Server.Models.Accounts;
using System.Collections.Generic;

namespace Sbazuo.Server.Backend {

	/// <summary>
	/// interface for creating sessions
	/// </summary>
	public interface ISessionService {

		/// <summary>
		/// create new session token
		/// </summary>
		/// <returns> session token </returns>
		string CreateSessionToken(string playerId);

		/// <summary>
		/// validating session token
		/// </summary>
		/// <param name="sessionToken"></param>
		/// <returns> true, if session token is valid </returns>
		bool ValidateSessionToken(string sessionToken);

		/// <summary>
		/// returns player id
		/// </summary>
		/// <param name="sessionToken"></param>
		/// <returns></returns>
		string GetPlayerIdBySessionToken(string sessionToken);

		/// <summary>
		/// returns all players in game
		/// </summary>
		/// <param name="sessionToken"></param>
		/// <returns></returns>
		IEnumerable<AccountInfo> GetPlayers();

	}
}
