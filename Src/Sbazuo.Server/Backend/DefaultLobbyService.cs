using Sbazuo.Server.Backend.Lobbies;
using Sbazuo.Server.Models.Lobbies;
using Sbazuo.Server.Utils;
using System.Collections.Generic;

namespace Sbazuo.Server.Backend {
	public class DefaultLobbyService : ILobbyService {

		private IDictionary<string, string> PlayerNicknameToRoomId;

		private IDictionary<string, ILobby> Lobbies;

		public IEnumerable<ILobby> CreatedLobbies => this.Lobbies.Values;

		public int LobbiesCount => Lobbies.Count;

		private readonly ILobbyFactory LobbyFactory;

		public DefaultLobbyService(ILobbyFactory lobbyFactory) {
			PlayerNicknameToRoomId = new Dictionary<string, string>();
			LobbyFactory = lobbyFactory;
			Lobbies = new Dictionary<string, ILobby>();
		}

		public ILobby CreateLobby(string playerNickname, string lobbyName) {
			ILobby createdRoom = LobbyFactory.CreateLobby(lobbyName, playerNickname);
			Lobbies.Add(createdRoom.Id, createdRoom);
			PlayerNicknameToRoomId.Add(playerNickname, createdRoom.Id);
			return createdRoom;
		}

		public ILobby GetLobbyByPlayerNickname(string playerNickname) {
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
			PlayerNicknameToRoomId.Add(playerNickname, lobbyId);
			Lobbies[lobbyId].Join(new LobbyJoinOptions { PlayerNickname = playerNickname } );
			return playerNickname;
		}

		public void LeaveLobby(string playerNickname) {
			InternalLeaveLobby(playerNickname);
		}

		private void InternalLeaveLobby(string playerNickname) {
			if (!PlayerNicknameToRoomId.ContainsKey(playerNickname)) {
				return;
			}
			string lobbyId = PlayerNicknameToRoomId[playerNickname];
			PlayerNicknameToRoomId.Remove(playerNickname);
			Lobbies[lobbyId].LeaveLobby(playerNickname);
			if (Lobbies[lobbyId].PlayersCount == 0) {
				Lobbies.Remove(lobbyId);
			}
		}

		public void StartLobby(string playerNickname) {
			
		}
	}
}
