using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Engine.Tests.Utils;
using Sbazuo.Geometry;

namespace Sbazuo.Engine.Tests.GameControls {

	[TestClass]
	public class GameControllerTests {

		[TestMethod]
		public void UpdateRemoveProjectileTest() {
			GameController controller = CreationUtils.CreateDefaultGame();
			int primaryProjectilesCount = controller.Projectiles.Count;

			IProjectile firstValidProjectile = CreationUtils.CreateDefaultProjectile();
			IProjectile secondValidProjectile = CreationUtils.CreateDefaultProjectile();

			IProjectile invalidProjectile = CreationUtils.CreateDefaultProjectile();
			invalidProjectile.Shape.Center = new Point2D(-10000, -10000);
			invalidProjectile.Health = -1;
			invalidProjectile.MotionVector = new Vector2D(0, 0);

			controller.Projectiles.Add(invalidProjectile);
			controller.Projectiles.Add(firstValidProjectile);
			controller.Projectiles.Add(secondValidProjectile);

			Assert.AreEqual(primaryProjectilesCount + 3, controller.Projectiles.Count);

			controller.Update();
			Assert.AreEqual(primaryProjectilesCount + 2, controller.Projectiles.Count);

			Assert.IsTrue(controller.Projectiles.Contains(firstValidProjectile));
			Assert.IsTrue(controller.Projectiles.Contains(secondValidProjectile));
			Assert.IsFalse(controller.Projectiles.Contains(invalidProjectile));
		}

	}
}
