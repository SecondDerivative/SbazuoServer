using Sbazuo.Engine.GameRules;
using Sbazuo.Geometry;

namespace Sbazuo.Engine.Projectiles {

	/// <summary>
	/// represents information about projectile
	/// </summary>
	public interface IProjectile : IHealthObject, IRule {

		/// <summary>
		/// gets or sets projectile motion vector
		/// </summary>
		Vector2D MotionVector { get; set; }

		/// <summary>
		/// gets projectile geometry shape
		/// </summary>
		Circle2D Shape { get; }

		/// <summary>
		/// gets player's owner id
		/// </summary>
		string OwnerId { get; }

	}
}
