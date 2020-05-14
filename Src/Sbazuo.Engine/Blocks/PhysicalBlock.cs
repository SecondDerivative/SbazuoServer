using Sbazuo.Engine.GameActions;
using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Engine.Projectiles.Collisions;
using Sbazuo.Engine.Shapes;
using Sbazuo.Geometry;
using System;

namespace Sbazuo.Engine.Blocks {

	/// <summary>
	/// class, represents information about simple physical block
	/// </summary>
	public class PhysicalBlock : Block, IHealthObject {

		public int Health { get; set; }

		public int MaxHealth { get; }

		public PhysicalBlock(string ownerId, string shapeId, Point2D position, int primaryHealth) : base(ownerId, shapeId, position) {
			MaxHealth = primaryHealth;
			Health = primaryHealth;
		}

		public override void ApplyToGameAction(GameAction action, GameController controller) {

		}

		public override IProjectileCollision HasCollision(IShapeProvider shapeProvider, IProjectile projectile) {
			Shape2D blockGeometry = shapeProvider.GetShape(Position, ShapeId);
			if (!projectile.Shape.HasIntersection(blockGeometry)) {
				return null;
			}
			foreach (var s in blockGeometry.Segments) {
				if (Math.Abs(GeometryUtils.DistanceToSegment(projectile.Shape.Center, s)) < projectile.Shape.Radius) {
					return new ProjectileSegmentCollision(projectile, this, s);
				}
			}
			throw new Exception("unknown collision data");
		}

		public override void Consume(GameAction action, GameController controller) {
			
		}
	}
}
