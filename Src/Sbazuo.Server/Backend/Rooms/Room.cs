using Sbazuo.Server.Utils;
namespace Sbazuo.Server.Backend.Rooms {
	public class Room {

		public readonly string Id;

		public Room(string id) {
			this.Id = id;
		}

		public string AddPlayer(string sessionId) {
			return StringGenerator.GenerateString();
		}

	}
}
