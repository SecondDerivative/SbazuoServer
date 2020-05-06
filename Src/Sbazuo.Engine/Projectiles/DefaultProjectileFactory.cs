using Sbazuo.Geometry;

namespace Sbazuo.Engine.Projectiles {
	public class DefaultProjectileFactory : IProjectileFactory {
		
		public IProjectile CreateProjectile(string id, string ownerId, double motionAngle, double velocityMultiphier, Point2D primaryPosition) {
			// @TODO
			return new DefaultProjectile(new Circle2D(primaryPosition, 2.5), new Vector2D(1, 0).GetRotatedVector(motionAngle) * 10 * velocityMultiphier, ownerId, 50);
		}
	}
}
