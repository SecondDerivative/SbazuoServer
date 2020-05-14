using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Engine.Projectiles.AliveConditions;
using Sbazuo.Engine.Tests.Utils;
using Sbazuo.Geometry;

namespace Sbazuo.Engine.Tests.Projectiles.AliveConditions {
	
	[TestClass]
	public class HealthAliveConditionTests {

		public void IsAliveTest() {
			IProjectileAliveCondition condition = new HealthAliveCondition();
			GameController controller = CreationUtils.CreateDefaultGame();
			IProjectile projectile = new DefaultProjectile(new Circle2D(new Point2D(1, 1), 0.1), new Vector2D(), null, 100);
			Assert.IsTrue(condition.IsAlive(controller, projectile));
			projectile.Health = -1;
			Assert.IsFalse(condition.IsAlive(controller, projectile));
		}

	}
}
