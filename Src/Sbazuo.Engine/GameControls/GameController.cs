using Sbazuo.Engine.Blocks;
using Sbazuo.Engine.GameRules;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Engine.Projectiles.ProjectileAliveConditions;
using System.Collections.Generic;
using System.Linq;

namespace Sbazuo.Engine.GameControls {

	/// <summary>
	/// represents class, which controlling once game
	/// </summary>
	public class GameController {

		/// <summary>
		/// gets active game rules
		/// </summary>
		public ICollection<IRule> GlobalGameRules { get; private set; }

		/// <summary>
		/// gets players blocks
		/// </summary>
		public ICollection<Block> Blocks { get; private set; }

		/// <summary>
		/// gets active projectiles
		/// </summary>
		public ICollection<IProjectile> Projectiles { get; private set; }

		/// <summary>
		/// gets current projectile alive condition
		/// </summary>
		public IProjectileAliveCondition ProjectileAliveCondition { get; private set; }

		/// <summary>
		/// updating game state
		/// </summary>
		public void Update() {
			List<IProjectile> localProjectiles = Projectiles.Where(x => ProjectileAliveCondition.IsAlive(this, x)).ToList();
			foreach (IProjectile proj in localProjectiles) {

			}
			Projectiles = localProjectiles;
		}

	}
}
