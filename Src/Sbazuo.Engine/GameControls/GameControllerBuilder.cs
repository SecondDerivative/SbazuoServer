using Sbazuo.Engine.GameMods;

namespace Sbazuo.Engine.GameControls {
	public class GameControllerBuilder {

		public GameController CreateGame(IGameMod gameMod, int playersCount) {
			return new GameController(gameMod, playersCount);
		}

	}
}
