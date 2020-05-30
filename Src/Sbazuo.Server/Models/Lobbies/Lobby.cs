using System.Collections.Generic;
using System.Linq;

namespace Sbazuo.Server.Models.Lobbies {

	/// <summary>
	/// represents information about lobbies
	/// </summary>
	public class Lobby : ILobby {

		public string Id { get; }

		public string CreatorNick { get; protected set; }

		public string LobbyName { get; protected set; }

		public int PlayersCount => PlayerNicknames.Count;

		/// <summary>
		/// array of lobby's players
		/// </summary>
		protected List<string> PlayerNicknames { get; set; }

		public string MapId { get; set; }

		public string ModId { get; set; }

		public LobbyStatus Status { get; set; }

		public Lobby(string id, string lobbyName, string creatorNick) {
			Id = id;
			CreatorNick = creatorNick;
			LobbyName = lobbyName;
			PlayerNicknames = new List<string> { creatorNick };
		}

		public virtual bool Join(LobbyJoinOptions joinOptions) {
			if (joinOptions is null) {
				return false;
			}
			PlayerNicknames.Add(joinOptions.PlayerNickname);
			return true;
		}

		public virtual void LeaveLobby(string playerNickname) {
			PlayerNicknames.Remove(playerNickname);
			if (playerNickname == CreatorNick) {
				CreatorNick = PlayerNicknames.FirstOrDefault();
			}
		}

	}
}
