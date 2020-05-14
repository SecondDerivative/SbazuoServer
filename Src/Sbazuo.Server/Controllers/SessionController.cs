using Microsoft.AspNetCore.Mvc;
using Sbazuo.Server.Backend;
using Sbazuo.Server.Backend.Rooms;
using Sbazuo.Server.Models.Responces;
using System.Linq;
using System.Threading.Tasks;

namespace Sbazuo.Server.Controllers {

	[Controller]
	public class SessionController : Controller {

		private readonly ISessionProvider SessionProvider;

		private readonly IRoomProvider RoomProvider;

		public SessionController(ISessionProvider sessionProvider, IRoomProvider roomProvider) : base() {
			this.SessionProvider = sessionProvider;
			this.RoomProvider = roomProvider;
		}

		public JoinResponce Join() {
			string sessionId = SessionProvider.CreateSessionToken();
			Room joinedRoom = RoomProvider.CreatedRooms.FirstOrDefault() ?? RoomProvider.CreateRoom(sessionId);
			string playerId = joinedRoom.AddPlayer(sessionId);
			return new JoinResponce() { PlayerId = playerId, Token = SessionProvider.CreateSessionToken() };
		}

	}
}
