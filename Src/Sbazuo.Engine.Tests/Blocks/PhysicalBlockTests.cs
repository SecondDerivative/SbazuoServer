using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbazuo.Engine.Blocks;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Engine.Projectiles.Collisions;
using Sbazuo.Engine.Shapes;
using Sbazuo.Engine.Tests.Utils;
using Sbazuo.Geometry;
using System.Collections.Generic;

namespace Sbazuo.Engine.Tests.Blocks {

	[TestClass]
	public class PhysicalBlockTests {

		[TestMethod]
		public void HasCollisionTest() {
			IShapeProvider shapeProvider = new RectangleShapeProvider(6, 5);
			PhysicalBlock block = new PhysicalBlock("id", null, new Point2D(), 100);
			IProjectile projectile = new DefaultProjectile(new Circle2D(new Point2D(4, 6), 1.5), new Vector2D(), "id2", 50);
			IProjectileCollision collision = block.HasCollision(shapeProvider, projectile);
			Assert.IsNotNull(collision);
			Assert.AreSame(collision.Block, block);
			Assert.AreSame(collision.Projectile, projectile);
		}

	}
}
