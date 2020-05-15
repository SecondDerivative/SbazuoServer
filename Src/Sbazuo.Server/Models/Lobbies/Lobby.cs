using Newtonsoft.Json;
using Sbazuo.Engine.GameControls;
using System.Collections.Generic;

namespace Sbazuo.Server.Models.Lobbies {

	public class Lobby {

		public readonly string Id;

		public readonly string CreatorNick;

		public readonly string LobbyName;

		[JsonIgnore]
		public int PlayersCount => PlayerNicknames.Count;

		public List<string> PlayerNicknames;

		public string MapId { get; set; }

		public string ModId { get; set; }

		public LobbyStatus Status { get; set; }

		[JsonConstructor]
		public Lobby(string id, string lobbyName, string creatorNick) {
			Id = id;
			CreatorNick = creatorNick;
			LobbyName = lobbyName;
			PlayerNicknames = new List<string> { creatorNick };
		}

		public string AddPlayer(string playerNickname) {
			PlayerNicknames.Add(playerNickname);
			return playerNickname;
		}

		public void RemovePlayer(string sessionId) {
			PlayerNicknames.Remove(sessionId);
		}

		public GameController CreateGame() {
			GameControllerBuilder builder = new GameControllerBuilder();
			return null;
		}

	}
}
