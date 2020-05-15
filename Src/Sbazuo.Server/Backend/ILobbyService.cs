using Sbazuo.Server.Models.Lobbies;
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
		/// <param name="playerNickname"> </param>
		/// <param name="roomId"> room's unique id </param>
		/// <returns> unique player's id </returns>
		string Join(string playerNickname, string roomId);

		/// <summary>
		/// leave session from room
		/// </summary>
		/// <param name="playerNickname"></param>
		void LeaveLobby(string playerNickname);

		/// <summary>
		/// creating new room
		/// </summary>
		/// <param name="playerNickname"></param>
		/// <returns> created room </returns>
		Lobby CreateLobby(string playerNickname, string lobbyName);

		/// <summary>
		/// returns room, which contains player
		/// </summary>
		/// <param name="playerNickname"></param>
		/// <returns></returns>
		Lobby GetLobbyByPlayerNickname(string playerNickname);

		/// <summary>
		/// starts game in lobby
		/// </summary>
		/// <param name="sessionId"></param>
		void StartLobby(string playerNickname);

	}
}
