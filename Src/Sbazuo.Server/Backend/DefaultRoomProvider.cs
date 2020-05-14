using Sbazuo.Server.Backend.Rooms;
using Sbazuo.Server.Utils;
using System.Collections.Generic;

namespace Sbazuo.Server.Backend {
	public class DefaultRoomProvider : IRoomProvider {

		private IDictionary<string, string> SessionIdToRoomId;

		private IDictionary<string, Room> Rooms;

		public IEnumerable<Room> CreatedRooms => this.Rooms.Values;

		public int RoomsCount => Rooms.Count;

		public DefaultRoomProvider() {
			SessionIdToRoomId = new Dictionary<string, string>();
			Rooms = new Dictionary<string, Room>();
		}

		public Room CreateRoom(string sessionId) {
			Room createdRoom = new Room(StringGenerator.GenerateString());
			Rooms.Add(createdRoom.Id, createdRoom);
			
			return createdRoom;
		}

		public Room GetSessionRoom(string sessionId) {
			throw new System.NotImplementedException();
		}

		public string Join(string sessionId, string roomId) {
			InternalLeaveRoom(sessionId);
			if (!Rooms.ContainsKey(roomId)) {
				return null;
			}
			return Rooms[roomId].AddPlayer(sessionId);
		}

		public void LeaveRoom(string sessionId) {
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
