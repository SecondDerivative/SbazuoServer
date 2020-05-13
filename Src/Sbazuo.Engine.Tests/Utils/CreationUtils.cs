using Sbazuo.Engine.GameMods;

namespace Sbazuo.Engine.Tests.Utils {
	internal static class CreationUtils {

		internal static IGameMod CreateDefaultGameMod() {
			return new RealTimeGameMod(1000, 800);
		}

	}
}
