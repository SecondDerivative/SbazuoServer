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

		public Vector2D ProjectileMotionVector { get; }

		/// <summary>
		/// block's segment collision member
		/// </summary>
		public Segment2D CollisionSegment { get; }

		/// <summary>
		/// create new instance of <see cref="ProjectileSegmentCollision"/>
		/// </summary>
		/// <param name="projectile"> first collision member </param>
		/// <param name="block"> second collision member </param>
		/// <param name="projectileMotionVector"></param>
		/// <param name="collisionSegment"> block's segment collision member </param>
		public ProjectileSegmentCollision(IProjectile projectile, Block block, Vector2D projectileMotionVector, Segment2D collisionSegment) {
			this.Projectile = projectile;
			this.Block = block;
			this.ProjectileMotionVector = projectileMotionVector;
			this.CollisionSegment = collisionSegment;
		}

		public Vector2D CreateReflectionVector() {
			Vector2D segmentVector = new Vector2D(CollisionSegment.A, CollisionSegment.B);
			double reflectionAngle = Vector2D.GetAngle(segmentVector, ProjectileMotionVector);
			double angleSign = Math.Sign(reflectionAngle);
			reflectionAngle = Math.Abs(reflectionAngle);
			reflectionAngle = Math.Min(reflectionAngle, Math.PI - reflectionAngle);
			reflectionAngle *= angleSign;
			return ProjectileMotionVector.GetRotatedVector(-2 * reflectionAngle); 
		}
	}
}
