namespace Sbazuo.Server.Models.Lobbies {

	/// <summary>
	/// represents information about lobby
	/// </summary>
	public interface ILobby {

		/// <summary>
		/// lobby's unique id
		/// </summary>
		string Id { get; }

		/// <summary>
		/// lobby's creator
		/// </summary>
		string CreatorNick { get; }

		/// <summary>
		/// lobby's name
		/// </summary>
		string LobbyName { get; }

		/// <summary>
		/// lobby's players count
		/// </summary>
		int PlayersCount { get; }

		/// <summary>
		/// selected map id
		/// </summary>
		string MapId { get; }

		/// <summary>
		/// selected mod id
		/// </summary>
		string ModId { get; }

		/// <summary>
		/// lobby's status (prepare or playing)
		/// </summary>
		LobbyStatus Status { get; }

		/// <summary>
		/// join player to lobby
		/// </summary>
		/// <param name="joinOptions"></param>
		/// <returns> true, if player joined </returns>
		bool Join(LobbyJoinOptions joinOptions);

		void LeaveLobby(string playerNickname);

	}
}
