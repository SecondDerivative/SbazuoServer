using Sbazuo.Geometry;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sbazuo.Engine.Projectiles {
	public interface IProjectileFactory {

		IProjectile CreateProjectile(string id, string ownerId, double motionAngle, double velocityMultiphier, Point2D primaryPosition);

	}
}
