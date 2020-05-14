using Sbazuo.Engine.GameControls;
using Sbazuo.Server.Utils;
using System.Collections.Generic;

namespace Sbazuo.Server.Backend.Lobbies {

	public class Lobby {

		public readonly string Id;

		public readonly string CreatorId;

		public ICollection<string> SessionsIds;

		public IDictionary<string, string> SessionIdToPlayerId;

		public string MapId { get; set; }

		public string ModId { get; set; }

		public Lobby(string id, string creatorId) {
			Id = id;
			CreatorId = creatorId;
			SessionIdToPlayerId = new Dictionary<string, string>();
			SessionsIds = new List<string>();
		}

		public string AddPlayer(string sessionId) {
			string playerId = StringGenerator.GenerateString();
			SessionsIds.Add(sessionId);
			SessionIdToPlayerId.Add(sessionId, playerId);
			return playerId;
		}

		public void RemovePlayer(string sessionId) {
			SessionIdToPlayerId.Remove(sessionId);
			SessionsIds.Remove(sessionId);
			//if (SessionIdToPlayerId.ContainsKey(sessionId))
		}

		public GameController CreateGame() {
			GameControllerBuilder builder = new GameControllerBuilder();
			return null;
			//builder.CreateGame()
		}

	}
}
