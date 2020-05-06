using Sbazuo.Engine.Blocks;
using Sbazuo.Geometry;

namespace Sbazuo.Engine.Projectiles.Collisions {

	/// <summary>
	/// represents data about collision projectile and block
	/// </summary>
	public interface IProjectileCollision {

		/// <summary>
		/// first collision member (projectile)
		/// </summary>
		IProjectile Projectile { get; }

		/// <summary>
		/// second collision member (block)
		/// </summary>
		Block Block { get; }

		/// <summary>
		/// if true, foreach-loop will stop rule applying
		/// </summary>
		bool BreakingRuleApply { get; }

		/// <summary>
		/// returns a primary projectile motion vector
		/// </summary>
		Vector2D ProjectileMotionVector { get; }

		/// <summary>
		/// returns new projectile motion vector
		/// </summary>
		Vector2D CreateReflectionVector();

	}
}
