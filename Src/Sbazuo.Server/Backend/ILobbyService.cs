using Sbazuo.Server.Backend.Lobbies;
using System.Collections.Generic;

namespace Sbazuo.Server.Backend {
	public interface ILobbyService {

		/// <summary>
		/// gets lobbies count
		/// </summary>
		int LobbiesCount { get; }

		/// <summary>
		/// gets created lobbies
		/// </summary>
		IEnumerable<Lobby> CreatedLobbies { get; }

		/// <summary>
		/// join session in room
		/// </summary>
		/// <param name="sessionId"> </param>
		/// <param name="roomId"> room's unique id </param>
		/// <returns> unique player's id </returns>
		string Join(string sessionId, string roomId);

		/// <summary>
		/// leave session from room
		/// </summary>
		/// <param name="sessionId"></param>
		void LeaveLobby(string sessionId);

		/// <summary>
		/// creating new room
		/// </summary>
		/// <param name="sessionId"></param>
		/// <returns> created room </returns>
		Lobby CreateLobby(string sessionId, string lobbyName);

		/// <summary>
		/// returns room, which contains session
		/// </summary>
		/// <param name="sessionId"></param>
		/// <returns></returns>
		Lobby GetSessionRoom(string sessionId);

		/// <summary>
		/// starts game in lobby
		/// </summary>
		/// <param name="sessionId"></param>
		void StartLobby(string sessionId);

	}
}
