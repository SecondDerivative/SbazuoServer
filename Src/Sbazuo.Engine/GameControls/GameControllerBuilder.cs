using Sbazuo.Engine.GameMaps;
using Sbazuo.Engine.GameMods;
using System.Collections.Generic;

namespace Sbazuo.Engine.GameControls {
	public class GameControllerBuilder {

		public GameController CreateGame(IGameMod gameMod, GameMap map, IEnumerable<string> playerIds) {
			return new GameController(gameMod, map, playerIds);
		}

	}
}
