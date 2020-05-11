using Sbazuo.Geometry;

namespace Sbazuo.Engine.Projectiles {

	/// <summary>
	/// factory for creating new projectiles
	/// </summary>
	public interface IProjectileFactory {

		IProjectile CreateProjectile(string id, string ownerId, double motionAngle, double velocityMultiphier, Point2D primaryPosition);

	}
}
