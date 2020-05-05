using Sbazuo.Engine.GameActions;
using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.GameRules;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Geometry;

namespace Sbazuo.Engine.Blocks {

	/// <summary>
	/// represents information about block
	/// </summary>
	public abstract class Block : IRule {

		/// <summary>
		/// block owner player id
		/// </summary>
		public readonly string OwnerId;

		/// <summary>
		/// block's shape
		/// </summary>
		public readonly Shape2D Shape;

		/// <summary>
		/// checks collision with projectile and returns collision data
		/// </summary>
		/// <returns> collision data or null, if hasn't collision </returns>
		public abstract IProjectileCollision HasCollision(IProjectile projectile);

		public abstract void ApplyToGameAction(GameAction action, GameController controller);
	}
}
