using Sbazuo.Server.Models.Lobbies;
using Sbazuo.Server.Models.Responces;
using System.Linq;

namespace Sbazuo.Server.Models.Converters {
	public class LobbyConverter : IConverter {

		public LobbyInfo Convert(Lobby model) {
			Lobby lobby = model as Lobby;
			return new LobbyInfo() { Id = lobby.Id, CreatorNickname = lobby.CreatorNick, LobbyName = lobby.LobbyName, MapId = lobby.MapId, ModId = lobby.ModId, PlayerNicks = lobby.Players.ToList() };
		}

	}
}
