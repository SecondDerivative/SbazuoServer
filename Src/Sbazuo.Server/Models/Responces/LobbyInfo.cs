using Sbazuo.Server.Models.Converters;
using Sbazuo.Server.Models.Converters.Attributes;
using Sbazuo.Server.Models.Lobbies;
using System.Collections.Generic;

namespace Sbazuo.Server.Models.Responces {

	[AllowConvert(typeof(Lobby))]
	[ModelConverter(typeof(LobbyConverter))]
	public class LobbyInfo {

		public string Id { get; set; }

		public string LobbyName { get; set; }

		public string CreatorId { get; set; }

		public LobbyStatus Status { get; set; }

		public List<string> PlayerIds { get; set; }

		public string MapId { get; set; }

		public string ModId { get; set; }

		public LobbyInfo() {
			PlayerIds = new List<string>();
		}

	}
}
