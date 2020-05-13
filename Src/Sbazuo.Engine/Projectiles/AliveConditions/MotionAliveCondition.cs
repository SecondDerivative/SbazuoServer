using Sbazuo.Engine.GameControls;
using Sbazuo.Geometry;

namespace Sbazuo.Engine.Projectiles.AliveConditions {
	
	/// <summary>
	/// represents alive condition where projectile's speed must be more than 0
	/// </summary>
	public class MotionAliveCondition : IProjectileAliveCondition {

		public bool IsAlive(GameController controller, IProjectile projectile) {
			return projectile.MotionVector.Length > GeometryUtils.Eps;
		}
	}
}
