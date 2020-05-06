using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbazuo.Engine.Blocks;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Engine.Projectiles.Collisions;
using Sbazuo.Geometry;
using System.Collections.Generic;

namespace Sbazuo.Engine.Tests.Projectiles.Collisions {

	[TestClass]
	public class ProjectileSegmentCollisionTests {

		[TestMethod]
		public void CreateReflectionVectorTest() {
			Shape2D shape = new Shape2D(new List<Point2D> { new Point2D(0, 0), new Point2D(0, 5), new Point2D(6, 5), new Point2D(6, 0) });
			PhysicalBlock block = new PhysicalBlock("id", shape, 100);
			IProjectile projectile = new DefaultProjectile(new Circle2D(new Point2D(4, 6), 1.5), new Vector2D(-1, -0.5), "id2", 50);
			ProjectileSegmentCollision collision = block.HasCollision(projectile) as ProjectileSegmentCollision;
			Vector2D reflection = collision.CreateReflectionVector();

			Assert.AreEqual(0, collision.CollisionSegment.A.X);
			Assert.AreEqual(5, collision.CollisionSegment.A.Y);
			Assert.AreEqual(6, collision.CollisionSegment.B.X);
			Assert.AreEqual(5, collision.CollisionSegment.B.Y);

			Assert.AreEqual(-1, reflection.X, GeometryUtils.Eps);
			Assert.AreEqual(0.5, reflection.Y, GeometryUtils.Eps);

			projectile.MotionVector = new Vector2D(0.7, -0.3);
			reflection = collision.CreateReflectionVector();
			Assert.AreEqual(0, collision.CollisionSegment.A.X);
			Assert.AreEqual(5, collision.CollisionSegment.A.Y);
			Assert.AreEqual(6, collision.CollisionSegment.B.X);
			Assert.AreEqual(5, collision.CollisionSegment.B.Y);

			Assert.AreEqual(0.7, reflection.X, GeometryUtils.Eps);
			Assert.AreEqual(0.3, reflection.Y, GeometryUtils.Eps);

			projectile.Shape.Center = new Point2D(6.5, 2);
			projectile.MotionVector = new Vector2D(-0.5, 0.1);

			collision = block.HasCollision(projectile) as ProjectileSegmentCollision;
			reflection = collision.CreateReflectionVector();
			Assert.AreEqual(6, collision.CollisionSegment.A.X);
			Assert.AreEqual(5, collision.CollisionSegment.A.Y);
			Assert.AreEqual(6, collision.CollisionSegment.B.X);
			Assert.AreEqual(0, collision.CollisionSegment.B.Y);

			Assert.AreEqual(0.5, reflection.X, GeometryUtils.Eps);
			Assert.AreEqual(0.1, reflection.Y, GeometryUtils.Eps);
		}

	}
}
