using Sbazuo.Engine.Blocks;
using Sbazuo.Engine.GameActions;
using Sbazuo.Engine.GameRules;
using Sbazuo.Engine.Players;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Engine.Projectiles.AliveConditions;
using System.Collections.Generic;
using System.Linq;

namespace Sbazuo.Engine.GameControls {

	/// <summary>
	/// represents class, which controlling once game
	/// </summary>
	public class GameController {

		/// <summary>
		/// gets current game rules
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
		/// gets current game action provider
		/// </summary>
		private readonly IGameActionProvider GameActionProvider;

		/// <summary>
		/// gets current projectile factory
		/// </summary>
		public readonly IProjectileFactory ProjectileFactory;

		/// <summary>
		/// gets current block factory
		/// </summary>
		public readonly IBlockFactory BlockFactory;

		/// <summary>
		/// gets current players
		/// </summary>
		public ICollection<Player> Players { get; private set; }

		public GameController() {
			Blocks = new List<Block>();
			Projectiles = new List<IProjectile>();
			
			ProjectileAliveConditionContainer aliveConditions = new ProjectileAliveConditionContainer();
			aliveConditions.Add(new HealthAliveCondition());
			ProjectileAliveCondition = aliveConditions;

			GlobalGameRules = new List<IRule>();
			GameActionProvider = new DefaultGameActionProvider(this);
			Players = new List<Player>();
			ProjectileFactory = new DefaultProjectileFactory();
			BlockFactory = new DefaultBlockFactory();
		}

		/// <summary>
		/// updating game state
		/// </summary>
		public void Update() {
			Projectiles = Projectiles.Where(x => ProjectileAliveCondition.IsAlive(this, x)).ToList();
			List<IProjectile> localProjectiles = Projectiles.ToList();
			foreach (IProjectile proj in localProjectiles) {
				GameActionProvider.ApplyGameAction(new GameActionMoveProjectile(proj));
			}
		}

		/// <summary>
		/// register game action to execute
		/// </summary>
		public void ApplyAction(GameAction action) {
			GameActionProvider.ApplyGameAction(action);
		}

	}
}
