using Sbazuo.Engine.Blocks;
using Sbazuo.Engine.GameActions;
using Sbazuo.Engine.GameMaps;
using Sbazuo.Engine.GameMods;
using Sbazuo.Engine.GameRules;
using Sbazuo.Engine.Players;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Engine.Projectiles.AliveConditions;
using Sbazuo.Engine.Shapes;
using Sbazuo.Engine.Triggers;
using Sbazuo.Geometry;
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
		/// gets current triggers
		/// </summary>
		public ICollection<ITrigger> Triggers { get; private set; }

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
		public IProjectileFactory ProjectileFactory => GameMod.ProjectileFactory;

		/// <summary>
		/// gets current block factory
		/// </summary>
		public IBlockFactory BlockFactory => GameMod.BlockFactory;

		/// <summary>
		/// gets current shape factory
		/// </summary>
		public IShapeProvider ShapeProvider => GameMod.ShapeProvider;

		/// <summary>
		/// gets current game field
		/// </summary>
		public Shape2D GameField => Map.GameField;

		/// <summary>
		/// gets current players
		/// </summary>
		public ICollection<Player> Players { get; private set; }

		/// <summary>
		/// gets current game mode
		/// </summary>
		public readonly IGameMod GameMod;

		/// <summary>
		/// gets current game map
		/// </summary>
		public readonly GameMap Map;

		/// <summary>
		/// create new instance of <see cref="GameController"/>
		/// </summary>
		/// <param name="gameMod"> current game mod </param>
		/// <param name="map"> game field </param>
		/// <param name="playerIds"> enumerable of current game players </param>
		public GameController(IGameMod gameMod, GameMap map, IEnumerable<string> playerIds) {
			this.GameMod = gameMod;
			this.Map = map;

			this.Blocks = GameMod.PrimaryBlocks?.ToList() ?? new List<Block>();
			this.GlobalGameRules = GameMod.PrimaryRules?.ToList() ?? new List<IRule>();
			this.ProjectileAliveCondition = GameMod.ProjectileAliveCondition;
			this.Triggers = GameMod.PrimaryTriggers?.ToList() ?? new List<ITrigger>();

			this.Projectiles = new List<IProjectile>();

			this.GameActionProvider = new DefaultGameActionProvider(this);

			this.Players = new List<Player>();
			var shapes = Map.GetPlayersAreas(playerIds);
			var catapults = Map.GetPlayerCatapults(playerIds);
			foreach (string id in playerIds) {
				Player player = new Player(id);
				player.CatapultPosition = catapults.Where(x => x.Key == id).First().Value;
				player.OwnAreasIds = shapes.Where(x => x.Value == id).Select(x => x.Key).ToList();
			}
		}

		/// <summary>
		/// updating game state
		/// </summary>
		public virtual void Update() {
			//Projectiles = Projectiles.Where(x => ProjectileAliveCondition.IsAlive(this, x)).ToList();
			List<IProjectile> localProjectiles = Projectiles.ToList();
			foreach (var projectile in Projectiles) {
				if (!ProjectileAliveCondition.IsAlive(this, projectile)) {
					ApplyAction(new GameActionRemoveProjectile(projectile));
				}
			}

			localProjectiles = Projectiles.ToList();
			foreach (IProjectile proj in localProjectiles) {
				GameActionProvider.ApplyGameAction(new GameActionMoveProjectile(proj));
			}
		}

		/// <summary>
		/// register game action to execute
		/// </summary>
		public virtual void ApplyAction(GameAction action) {
			GameActionProvider.ApplyGameAction(action);
		}

	}
}
