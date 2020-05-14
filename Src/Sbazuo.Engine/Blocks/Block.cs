using Sbazuo.Engine.GameActions;
using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.GameRules;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Engine.Projectiles.Collisions;
using Sbazuo.Engine.Shapes;
using Sbazuo.Engine.Triggers;
using Sbazuo.Geometry;

namespace Sbazuo.Engine.Blocks {

	/// <summary>
	/// represents information about block
	/// </summary>
	public abstract class Block : IRule, ITrigger {

		/// <summary>
		/// block owner player id
		/// </summary>
		public readonly string OwnerId;

		/// <summary>
		/// block's shape
		/// </summary>
		public readonly string ShapeId;

		/// <summary>
		/// block's position
		/// </summary>
		public readonly Point2D Position;

		protected Block(string ownerId, string shapeId, Point2D position) {
			this.OwnerId = ownerId;
			this.ShapeId = shapeId;
			this.Position = position;
		}

		/// <summary>
		/// checks collision with projectile and returns collision data
		/// </summary>
		/// <returns> collision data or null, if hasn't collision </returns>
		public abstract IProjectileCollision HasCollision(IShapeProvider shapeProvider, IProjectile projectile);

		public abstract void ApplyToGameAction(GameAction action, GameController controller);

		public abstract void Consume(GameAction action, GameController controller);
	}
}
