using Sbazuo.Engine.GameMods;
using System.Collections.Generic;

namespace Sbazuo.Engine.GameControls {
	public class GameControllerBuilder {

		public GameController CreateGame(IGameMod gameMod, IEnumerable<string> playerIds) {
			return new GameController(gameMod, playerIds);
		}

	}
}
