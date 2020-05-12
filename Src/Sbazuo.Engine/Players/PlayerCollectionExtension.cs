using System.Collections.Generic;

namespace Sbazuo.Engine.Players {
	internal static class PlayerCollectionExtension {

		public static Player GetPlayer(this IEnumerable<Player> players, string id) {
			foreach (var p in players) {
				if (p.Id == id) {
					return p;
				}
			}
			return null;
		}

	}
}
