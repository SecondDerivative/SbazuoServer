using Sbazuo.Server.Backend.Lobbies;
using System.Collections.Generic;

namespace Sbazuo.Server.Models.Responces {

	public class LobbyInfo {

		public string LobbyName { get; set; }

		public string CreatorNickname { get; set; }

		public LobbyStatus Status { get; set; }

		public List<string> PlayerNicks { get; set; }

		public string MapId { get; set; }

		public string ModId { get; set; }

		public LobbyInfo() {
			PlayerNicks = new List<string>();
		}

	}
}
