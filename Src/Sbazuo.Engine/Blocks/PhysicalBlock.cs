using Sbazuo.Engine.GameActions;
using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Engine.Projectiles.Collisions;
using Sbazuo.Geometry;
using System;

namespace Sbazuo.Engine.Blocks {

	/// <summary>
	/// class, represents information about simple physical block
	/// </summary>
	public class PhysicalBlock : Block, IHealthObject {

		public int Health { get; set; }

		public int MaxHealth { get; }

		public PhysicalBlock(string ownerId, Shape2D shape, int primaryHealth) : base(ownerId, shape) {
			MaxHealth = primaryHealth;
			Health = primaryHealth;
		}

		public override void ApplyToGameAction(GameAction action, GameController controller) {

		}

		public override IProjectileCollision HasCollision(IProjectile projectile) {
			if (!projectile.Shape.HasIntersection(Shape)) {
				return null;
			}
			foreach (var s in Shape.Segments) {
				if (Math.Abs(GeometryUtils.DistanceToSegment(projectile.Shape.Center, s)) < projectile.Shape.Radius) {
					return new ProjectileSegmentCollision(projectile, this, s);
				}
			}
			throw new Exception("unknown collision data");
		}
	}
}
