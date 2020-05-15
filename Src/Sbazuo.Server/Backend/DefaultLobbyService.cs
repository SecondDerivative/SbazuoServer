using Sbazuo.Server.Models.Lobbies;
using Sbazuo.Server.Utils;
using System.Collections.Generic;

namespace Sbazuo.Server.Backend {
	public class DefaultLobbyService : ILobbyService {

		private IDictionary<string, string> PlayerNicknameToRoomId;

		private IDictionary<string, Lobby> Lobbies;

		public IEnumerable<Lobby> CreatedLobbies => this.Lobbies.Values;

		public int LobbiesCount => Lobbies.Count;

		public DefaultLobbyService() {
			PlayerNicknameToRoomId = new Dictionary<string, string>();
			Lobbies = new Dictionary<string, Lobby>();
		}

		public Lobby CreateLobby(string playerNickname, string lobbyName) {
			Lobby createdRoom = new Lobby(StringGenerator.GenerateString(), lobbyName, playerNickname);
			//createdRoom.AddPlayer(playerNickname);
			Lobbies.Add(createdRoom.Id, createdRoom);
			
			return createdRoom;
		}

		public Lobby GetLobbyByPlayerNickname(string playerNickname) {
			if (!PlayerNicknameToRoomId.ContainsKey(playerNickname)) {
				return null;
			}
			string lobbyId = PlayerNicknameToRoomId[playerNickname];
			if (!Lobbies.ContainsKey(lobbyId)) {
				return null;
			}
			return Lobbies[lobbyId];
		}

		public string Join(string playerNickname, string lobbyId) {
			InternalLeaveLobby(playerNickname);
			if (!Lobbies.ContainsKey(lobbyId)) {
				return null;
			}
			return Lobbies[lobbyId].AddPlayer(playerNickname);
		}

		public void LeaveLobby(string sessionId) {
			InternalLeaveLobby(sessionId);
		}

		private void InternalLeaveLobby(string playerNickname) {
			if (!PlayerNicknameToRoomId.ContainsKey(playerNickname)) {
				return;
			}
			string lobbyId = PlayerNicknameToRoomId[playerNickname];
			PlayerNicknameToRoomId.Remove(playerNickname);
			if (Lobbies[lobbyId].PlayersCount == 0) {
				Lobbies.Remove(lobbyId);
			}
		}

		public void StartLobby(string sessionId) {
			
		}
	}
}
