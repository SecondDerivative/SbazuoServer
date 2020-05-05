using Sbazuo.Engine.GameControls;
using System.Collections.Generic;

namespace Sbazuo.Engine.Projectiles.ProjectileAliveConditions {
	public class ProjectileAliveConditionContainer : List<IProjectileAliveCondition>, IProjectileAliveCondition {

		public bool IsAlive(GameController controller, IProjectile projectile) {
			foreach (var cond in this) {
				if (!cond.IsAlive(controller, projectile)) {
					return false;
				}
			}
			return true;
		}
	}
}
