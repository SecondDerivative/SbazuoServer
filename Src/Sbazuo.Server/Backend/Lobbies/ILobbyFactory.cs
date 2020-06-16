using Sbazuo.Server.Models.Lobbies;

namespace Sbazuo.Server.Backend.Lobbies {
	public interface ILobbyFactory {

		ILobby CreateLobby(string lobbyName, string creatorId);

	}
}
