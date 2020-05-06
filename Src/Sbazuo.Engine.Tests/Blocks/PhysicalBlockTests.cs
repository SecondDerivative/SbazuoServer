using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbazuo.Engine.Blocks;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Engine.Projectiles.Collisions;
using Sbazuo.Geometry;
using System.Collections.Generic;

namespace Sbazuo.Engine.Tests.Blocks {

	[TestClass]
	public class PhysicalBlockTests {

		[TestMethod]
		public void HasCollisionTest() {
			Shape2D shape = new Shape2D(new List<Point2D> { new Point2D(0, 0), new Point2D(0, 5), new Point2D(6, 5), new Point2D(6, 0) });
			PhysicalBlock block = new PhysicalBlock("id", shape, 100);
			IProjectile projectile = new DefaultProjectile(new Circle2D(new Point2D(4, 6), 1.5), new Vector2D(), "id2", 50);
			IProjectileCollision collision = block.HasCollision(projectile);
			Assert.IsNotNull(collision);
			Assert.AreSame(collision.Block, block);
			Assert.AreSame(collision.Projectile, projectile);
		}

	}
}
