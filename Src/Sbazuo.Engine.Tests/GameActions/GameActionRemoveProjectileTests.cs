using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbazuo.Engine.GameActions;
using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Engine.Tests.Utils;

namespace Sbazuo.Engine.Tests.GameActions {

	[TestClass]
	public class GameActionRemoveProjectileTests {

		[TestMethod]
		public void CreationTest() {
			IProjectile removedProjectile = CreationUtils.CreateDefaultProjectile();
			GameActionRemoveProjectile action = new GameActionRemoveProjectile(removedProjectile);
			Assert.AreEqual(removedProjectile.OwnerId, action.InstigatorId);
			Assert.AreSame(removedProjectile, action.Projectile);
		}

		[TestMethod]
		public void ApplyTest() {
			GameController controller = CreationUtils.CreateDefaultGame();
			int primaryProjectilesCount = controller.Projectiles.Count;
			IProjectile removedProjectile = CreationUtils.CreateDefaultProjectile();
			controller.Projectiles.Add(removedProjectile);
			Assert.AreEqual(primaryProjectilesCount + 1, controller.Projectiles.Count);

			GameActionRemoveProjectile action = new GameActionRemoveProjectile(removedProjectile);
			controller.ApplyAction(action);
			Assert.AreEqual(primaryProjectilesCount, controller.Projectiles.Count);
		}

		[TestMethod]
		public void ApplyToMultiProjectilesTest() {
			GameController controller = CreationUtils.CreateDefaultGame();
			int primaryProjectilesCount = controller.Projectiles.Count;

			IProjectile validProjectile = CreationUtils.CreateDefaultProjectile();
			IProjectile invalidProjectile = CreationUtils.CreateDefaultProjectile();

			controller.Projectiles.Add(validProjectile);
			controller.Projectiles.Add(invalidProjectile);

			Assert.AreEqual(primaryProjectilesCount + 2, controller.Projectiles.Count);

			GameActionRemoveProjectile action = new GameActionRemoveProjectile(invalidProjectile);
			controller.ApplyAction(action);

			Assert.AreEqual(primaryProjectilesCount + 1, controller.Projectiles.Count);
			Assert.IsTrue(controller.Projectiles.Contains(validProjectile));
			Assert.IsFalse(controller.Projectiles.Contains(invalidProjectile));
		}

	}
}
