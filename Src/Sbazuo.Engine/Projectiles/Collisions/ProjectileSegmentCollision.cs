using Sbazuo.Engine.Blocks;
using Sbazuo.Geometry;
using System;

namespace Sbazuo.Engine.Projectiles.Collisions {

	/// <summary>
	/// represents information about "simple" collision with once segment
	/// </summary>
	public class ProjectileSegmentCollision : IProjectileCollision {

		public IProjectile Projectile { get; }

		public Block Block { get; }

		public bool BreakingRuleApply => true;

		/// <summary>
		/// block's segment collision member
		/// </summary>
		public Segment2D CollisionSegment { get; }

		/// <summary>
		/// create new instance of <see cref="ProjectileSegmentCollision"/>
		/// </summary>
		/// <param name="projectile"> first collision member </param>
		/// <param name="block"> second collision member </param>
		/// <param name="collisionSegment"> block's segment collision member </param>
		public ProjectileSegmentCollision(IProjectile projectile, Block block, Segment2D collisionSegment) {
			this.Projectile = projectile;
			this.Block = block;
			this.CollisionSegment = collisionSegment;
		}

		public Vector2D CreateReflectionVector() {
			Vector2D segmentVector = new Vector2D(CollisionSegment.A, CollisionSegment.B);
			double reflectionAngle = Vector2D.GetAngle(segmentVector, Projectile.MotionVector);
			Console.WriteLine("prim refl angle " + reflectionAngle);
			//double angleSign = Math.Sign(reflectionAngle);
			//reflectionAngle = Math.Abs(reflectionAngle);
			//Console.WriteLine("angle sign");
			//reflectionAngle = Math.Min(reflectionAngle, Math.PI - reflectionAngle);
			Console.WriteLine("ost refl angle " + reflectionAngle);
			//reflectionAngle *= angleSign;
			Console.WriteLine("result rotated angle " + (-2 * reflectionAngle));
			return Projectile.MotionVector.GetRotatedVector(-2 * reflectionAngle); 
		}
	}
}
