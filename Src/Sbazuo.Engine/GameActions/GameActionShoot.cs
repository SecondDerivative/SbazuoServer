using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.Players;
using Sbazuo.Engine.Projectiles;

namespace Sbazuo.Engine.GameActions {

	/// <summary>
	/// represents information about shooting new projectile gameaction
	/// </summary>
	public class GameActionShoot : GameAction {

		/// <summary>
		/// created projectile id
		/// </summary>
		public readonly string ProjectileId;

		/// <summary>
		/// projectile velocity multiphier
		/// </summary>
		public double VelocityMult { get; set; }

		/// <summary>
		/// projectile motion angle
		/// </summary>
		public readonly double MotionAngle;

		/// <summary>
		/// create new instance of <see cref="GameActionShoot"/>
		/// </summary>
		public GameActionShoot(string instigatorId, string projectileId, double motionAngle, double velocityMult) : base(instigatorId) {
			this.ProjectileId = projectileId;
			this.VelocityMult = velocityMult;
			this.MotionAngle = motionAngle;
		}

		public override void ApplyToGame(GameController controller) {
			IProjectile proj = controller.ProjectileFactory.CreateProjectile(ProjectileId, InstigatorId, MotionAngle, VelocityMult, controller.Players.GetPlayer(InstigatorId).CatapultPosition);
			controller.Projectiles.Add(proj);
		}

	}
}
