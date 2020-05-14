using Sbazuo.Engine.GameControls;

namespace Sbazuo.Engine.Projectiles.AliveConditions {

	/// <summary>
	/// represents projectile alive condition
	/// </summary>
	public interface IProjectileAliveCondition {

		/// <summary>
		/// check projectile alive
		/// </summary>
		/// <returns> false, if projectile should be removed </returns>
		bool IsAlive(GameController controller, IProjectile projectile);

	}
}
