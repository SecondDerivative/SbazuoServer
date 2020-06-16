using Sbazuo.Server.Backend.Lobbies;
using Sbazuo.Server.Models.Lobbies;
using System.Collections.Generic;

namespace Sbazuo.Server.Backend {
	public class DefaultLobbyService : ILobbyService {

#pragma warning disable IDE0044
		private IDictionary<string, string> PlayerIdToRoomId;

		private IDictionary<string, ILobby> Lobbies;
#pragma warning restore IDE0044

		public IEnumerable<ILobby> CreatedLobbies => this.Lobbies.Values;

		public int LobbiesCount => Lobbies.Count;

		private readonly ILobbyFactory LobbyFactory;

		public DefaultLobbyService(ILobbyFactory lobbyFactory) {
			PlayerIdToRoomId = new Dictionary<string, string>();
			LobbyFactory = lobbyFactory;
			Lobbies = new Dictionary<string, ILobby>();
		}

		public ILobby CreateLobby(string playerId, string lobbyName) {
			ILobby createdRoom = LobbyFactory.CreateLobby(lobbyName, playerId);
			Lobbies.Add(createdRoom.Id, createdRoom);
			PlayerIdToRoomId.Add(playerId, createdRoom.Id);
			return createdRoom;
		}

		public ILobby GetLobbyByPlayerId(string playerId) {
			if (!PlayerIdToRoomId.ContainsKey(playerId)) {
				return null;
			}
			string lobbyId = PlayerIdToRoomId[playerId];
			if (!Lobbies.ContainsKey(lobbyId)) {
				return null;
			}
			return Lobbies[lobbyId];
		}

		public string Join(string playerId, string lobbyId) {
			InternalLeaveLobby(playerId);
			if (!Lobbies.ContainsKey(lobbyId)) {
				return null;
			}
			PlayerIdToRoomId.Add(playerId, lobbyId);
			Lobbies[lobbyId].Join(new LobbyJoinOptions { PlayerNickname = playerId } );
			return playerId;
		}

		public void LeaveLobby(string playerId) {
			InternalLeaveLobby(playerId);
		}

		private void InternalLeaveLobby(string playerId) {
			if (!PlayerIdToRoomId.ContainsKey(playerId)) {
				return;
			}
			string lobbyId = PlayerIdToRoomId[playerId];
			PlayerIdToRoomId.Remove(playerId);
			Lobbies[lobbyId].LeaveLobby(playerId);
			if (Lobbies[lobbyId].PlayersCount == 0) {
				Lobbies.Remove(lobbyId);
			}
		}

		public void StartLobby(string playerId) {
			
		}
	}
}
