using Sbazuo.Engine.GameControls;

namespace Sbazuo.Engine.Projectiles.AliveConditions {

	/// <summary>
	/// represents alive condition where projectile must be in game field
	/// </summary>
	public class InnerGameFieldAliveCondition : IProjectileAliveCondition {

		public bool IsAlive(GameController controller, IProjectile projectile) {
			return controller.GameField.ContainsPoint(projectile.Shape.Center);
		}
	}
}
