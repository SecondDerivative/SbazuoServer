using Sbazuo.Engine.Blocks;
using Sbazuo.Geometry;

namespace Sbazuo.Engine.Projectiles {

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
		/// if true, 
		/// </summary>
		bool BreakingRuleApply { get; }

		/// <summary>
		/// if false, projectile position will not be update
		/// </summary>
		bool UpdateProjectilePosition { get; }

		/// <summary>
		/// returns new projectile motion vector
		/// </summary>
		Vector2D CreateReflectionVector();

	}
}
