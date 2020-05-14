using Sbazuo.Server.Backend.Lobbies;
using Sbazuo.Server.Utils;
using System.Collections.Generic;

namespace Sbazuo.Server.Backend {
	public class DefaultLobbyService : ILobbyService {

		private IDictionary<string, string> SessionIdToRoomId;

		private IDictionary<string, Lobby> Rooms;

		public IEnumerable<Lobby> CreatedLobbies => this.Rooms.Values;

		public int LobbiesCount => Rooms.Count;

		public DefaultLobbyService() {
			SessionIdToRoomId = new Dictionary<string, string>();
			Rooms = new Dictionary<string, Lobby>();
		}

		public Lobby CreateLobby(string sessionId, string lobbyName) {
			Lobby createdRoom = new Lobby(StringGenerator.GenerateString(), lobbyName);
			createdRoom.AddPlayer(sessionId);
			Rooms.Add(createdRoom.Id, createdRoom);
			
			return createdRoom;
		}

		public Lobby GetSessionRoom(string sessionId) {
			throw new System.NotImplementedException();
		}

		public string Join(string sessionId, string roomId) {
			InternalLeaveRoom(sessionId);
			if (!Rooms.ContainsKey(roomId)) {
				return null;
			}
			return Rooms[roomId].AddPlayer(sessionId);
		}

		public void LeaveLobby(string sessionId) {
			InternalLeaveRoom(sessionId);
		}

		private void InternalLeaveRoom(string sessionId) {
			if (!SessionIdToRoomId.ContainsKey(sessionId)) {
				return;
			}
			SessionIdToRoomId.Remove(sessionId);
		}
	}
}
