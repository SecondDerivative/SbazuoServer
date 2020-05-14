using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.GameMaps;
using Sbazuo.Engine.GameMods;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Geometry;

namespace Sbazuo.Engine.Tests.Utils {
	internal static class CreationUtils {

		internal const string DefaultProjectileId = "proj";

		internal static IGameMod CreateDefaultGameMod() {
			return new RealTimeGameMod();
		}

		internal static IProjectile CreateDefaultProjectile() {
			return new DefaultProjectile(new Circle2D(new Point2D(10, 10), 0.1), new Vector2D(1, 0), "a", 100);
		}

		internal static GameController CreateDefaultGame() {
			return new GameController(CreateDefaultGameMod(), new RectangleMap("rm", 1000, 800), new string[] { "a", "b", "c", "d" });
		}

	}
}
