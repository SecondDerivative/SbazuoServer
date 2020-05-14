using Sbazuo.Engine.GameControls;

namespace Sbazuo.Engine.Projectiles.AliveConditions {

	/// <summary>
	/// represents alive condition where projectile's health must be more than 0
	/// </summary>
	public class HealthAliveCondition : IProjectileAliveCondition {

		public bool IsAlive(GameController controller, IProjectile projectile) {
			return projectile.Health > 0;
		}

	}
}
