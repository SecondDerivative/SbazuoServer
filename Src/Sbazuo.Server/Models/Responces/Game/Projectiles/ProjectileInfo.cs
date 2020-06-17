using Sbazuo.Engine.Projectiles;
using Sbazuo.Server.Models.Converters;
using Sbazuo.Server.Models.Converters.Attributes;
using Sbazuo.Server.Models.Game;

namespace Sbazuo.Server.Models.Responces.Game.Projectiles {

	[AllowConvert(typeof(IProjectile))]
	[ModelConverter(typeof(ProjectileConverter))]
	public class ProjectileInfo {

		public string ProjectileId { get; set; }

		public Point Position { get; set; }

		public double Radius { get; set; }

		public Point MotionVector { get; set; }

		public string OwnerId { get; set; }

		public int Health { get; set; }

		public int MaxHealth { get; set; }

	}
}
