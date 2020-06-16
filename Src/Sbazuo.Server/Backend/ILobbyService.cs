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
		IEnumerable<ILobby> CreatedLobbies { get; }

		/// <summary>
		/// join session in room
		/// </summary>
		/// <param name="playerId"> </param>
		/// <param name="roomId"> room's unique id </param>
		/// <returns> unique player's id </returns>
		string Join(string playerId, string roomId);

		/// <summary>
		/// leave session from room
		/// </summary>
		/// <param name="playerId"></param>
		void LeaveLobby(string playerId);

		/// <summary>
		/// creating new room
		/// </summary>
		/// <param name="playerId"></param>
		/// <returns> created room </returns>
		ILobby CreateLobby(string playerId, string lobbyName);

		/// <summary>
		/// returns room, which contains player
		/// </summary>
		/// <param name="playerId"></param>
		/// <returns></returns>
		ILobby GetLobbyByPlayerId(string playerId);

		/// <summary>
		/// starts game in lobby
		/// </summary>
		/// <param name="sessionId"></param>
		void StartLobby(string playerId);

	}
}
