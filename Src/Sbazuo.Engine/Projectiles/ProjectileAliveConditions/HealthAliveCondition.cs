using Sbazuo.Engine.GameControls;

namespace Sbazuo.Engine.Projectiles.ProjectileAliveConditions {
	public class HealthAliveCondition : IProjectileAliveCondition {

		public bool IsAlive(GameController controller, IProjectile projectile) {
			return projectile.Health <= 0;
		}

	}
}
