using Sbazuo.Server.Backend;
using Sbazuo.Server.Backend.Lobbies;
using Sbazuo.Server.Models.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sbazuo.Server.Models.Converters {
	public class LobbyConverter {

		public LobbyInfo Convert(ISessionService sessionProvider, Lobby lobby) {
			return new LobbyInfo() { CreatorNickname = "", LobbyName = "", MapId = lobby.MapId, ModId = lobby.ModId, PlayerNicks = lobby. }
		}

	}
}
