using Sbazuo.Server.Backend.Rooms;
using System.Collections.Generic;

namespace Sbazuo.Server.Backend {
	public interface IRoomProvider {

		int RoomsCount { get; }

		IEnumerable<Room> CreatedRooms { get; }

		/// <summary>
		/// join session in room
		/// </summary>
		/// <param name="sessionId"> </param>
		/// <param name="roomId"> room's unique id </param>
		/// <returns> unique player's id </returns>
		string Join(string sessionId, string roomId);

		/// <summary>
		/// leave session from room
		/// </summary>
		/// <param name="sessionId"></param>
		void LeaveRoom(string sessionId);

		/// <summary>
		/// creating new room
		/// </summary>
		/// <param name="sessionId"></param>
		/// <returns> created room </returns>
		Room CreateRoom(string sessionId);

		/// <summary>
		/// returns room, which contains session
		/// </summary>
		/// <param name="sessionId"></param>
		/// <returns></returns>
		Room GetSessionRoom(string sessionId);

	}
}
