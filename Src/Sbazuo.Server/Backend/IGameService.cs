using Sbazuo.Server.Models.Game;
using System.Collections.Generic;

namespace Sbazuo.Server.Backend {
	public interface IGameService {

		public string RegisterGame(string mapId, string modId, IEnumerable<string> playerIds);

		public void GameCreateBlock(string playerId, string blockId, string shapeId, Point point);

		public void GameShoot(string playerId, string projectileId, Point direction);

	}
}
