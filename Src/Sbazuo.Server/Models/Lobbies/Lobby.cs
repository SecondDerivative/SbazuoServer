using System.Collections.Generic;
using System.Linq;

namespace Sbazuo.Server.Models.Lobbies {

	/// <summary>
	/// represents information about lobbies
	/// </summary>
	public class Lobby : ILobby {

		public string Id { get; }

		public string CreatorId { get; protected set; }

		public string LobbyName { get; protected set; }

		public int PlayersCount => Players.Count;

		/// <summary>
		/// array of lobby's players
		/// </summary>
		protected List<string> Players { get; set; }

		public string MapId { get; set; }

		public string ModId { get; set; }

		public LobbyStatus Status { get; set; }

		public IEnumerable<string> PlayerIds => Players;

		public Lobby(string id, string lobbyName, string creatorId) {
			Id = id;
			CreatorId = creatorId;
			LobbyName = lobbyName;
			Players = new List<string> { creatorId };
		}

		public virtual bool Join(LobbyJoinOptions joinOptions) {
			if (joinOptions is null) {
				return false;
			}
			Players.Add(joinOptions.PlayerNickname);
			return true;
		}

		public virtual void LeaveLobby(string playerId) {
			Players.Remove(playerId);
			if (playerId == CreatorId) {
				CreatorId = Players.FirstOrDefault();
			}
		}

	}
}
