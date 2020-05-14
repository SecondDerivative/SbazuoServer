using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.Projectiles.Collisions;

namespace Sbazuo.Engine.GameActions {

	/// <summary>
	/// represents information about collision action
	/// </summary>
	public class GameActionCollision : GameAction {

		public readonly IProjectileCollision Collision;

		/// <summary>
		/// create new instance of <see cref="GameActionCollision"/>
		/// </summary>
		/// <param name="collision"></param>
		public GameActionCollision(IProjectileCollision collision) : base(collision.Projectile.OwnerId) {
			this.Collision = collision;
		}

		public override void ApplyToGame(GameController controller) {
			
		}
	}
}
