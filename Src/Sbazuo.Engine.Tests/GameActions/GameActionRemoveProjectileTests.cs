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
			int primaryPorjectilesCount = controller.Projectiles.Count;
			IProjectile removedProjectile = CreationUtils.CreateDefaultProjectile();
			controller.Projectiles.Add(removedProjectile);
			Assert.AreEqual(primaryPorjectilesCount + 1, controller.Projectiles.Count);

			GameActionRemoveProjectile action = new GameActionRemoveProjectile(removedProjectile);
			controller.ApplyAction(action);
			Assert.AreEqual(primaryPorjectilesCount, controller.Projectiles.Count);
		}

	}
}
