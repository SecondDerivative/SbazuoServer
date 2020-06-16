using Sbazuo.Engine.Projectiles;
using Sbazuo.Server.Models.Responces.Game.Projectiles;

namespace Sbazuo.Server.Models.Converters {

	public class ProjectileConverter : Converter {

		public ProjectileInfo Convert(IProjectile projectile) {
			// TODO replace contantly projectile id
			return new ProjectileInfo() { Health = projectile.Health, MaxHealth = projectile.MaxHealth, MotionVector = new Game.Point(projectile.MotionVector), OwnerId = projectile.OwnerId, Position = new Game.Point(projectile.Shape.Center), ProjectileId = "projectile", Radius = projectile.Shape.Radius };
		}

	}
}
