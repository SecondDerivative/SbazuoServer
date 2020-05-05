using Sbazuo.Engine.GameControls;

namespace Sbazuo.Engine.Projectiles.ProjectileAliveConditions {

	/// <summary>
	/// represents condition
	/// </summary>
	public interface IProjectileAliveCondition {

		/// <summary>
		/// check projectile alive
		/// </summary>
		bool IsAlive(GameController controller, IProjectile projectile);

	}
}
