using Sbazuo.Server.Models.Lobbies;
using Sbazuo.Server.Utils;

namespace Sbazuo.Server.Backend.Lobbies {

	public class DefaultLobbyFactory : ILobbyFactory {
		public ILobby CreateLobby(string lobbyName, string creatorId) {
			return new Lobby(StringGenerator.GenerateString(), lobbyName, creatorId);
		}
	}
}
