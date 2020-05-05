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
		/// gets or sets projectile position point
		/// </summary>
		Point2D Position { get; set; }

		/// <summary>
		/// gets player's owner id
		/// </summary>
		string OwnerId { get; }

	}
}
