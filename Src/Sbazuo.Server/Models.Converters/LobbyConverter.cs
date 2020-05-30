using Sbazuo.Server.Models.Lobbies;
using Sbazuo.Server.Models.Responces;

namespace Sbazuo.Server.Models.Converters {
	public class LobbyConverter : IConverter {

		public object Convert(object model) {
			Lobby lobby = model as Lobby;
			return new LobbyInfo() { Id = lobby.Id, CreatorNickname = lobby.CreatorNick, LobbyName = lobby.LobbyName, MapId = lobby.MapId, ModId = lobby.ModId };
		}

	}
}
