using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.GameMaps;
using Sbazuo.Engine.GameMods;

namespace Sbazuo.Engine.Tests.Utils {
	internal static class CreationUtils {

		internal static IGameMod CreateDefaultGameMod() {
			return new RealTimeGameMod();
		}

		internal static GameController CreateDefaultGame() {
			return new GameController(CreateDefaultGameMod(), new RectangleMap("", 1000, 800), new string[] { "a", "b", "c", "d" });
		}

	}
}
