﻿using Sbazuo.Engine.Blocks;
using Sbazuo.Engine.GameActions;
using Sbazuo.Engine.GameMods;
using Sbazuo.Engine.GameRules;
using Sbazuo.Engine.Players;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Engine.Projectiles.AliveConditions;
using Sbazuo.Engine.Shapes;
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
		/// gets current players
		/// </summary>
		public ICollection<Player> Players { get; private set; }

		/// <summary>
		/// gets current game mode
		/// </summary>
		protected readonly IGameMod GameMod;

		/// <summary>
		/// create new instance of <see cref="GameController"/>
		/// </summary>
		/// <param name="gameMod"> current game mod </param>
		/// <param name="playerIds"> enumerable of current game players </param>
		public GameController(IGameMod gameMod, IEnumerable<string> playerIds) {
			GameMod = gameMod;

			Blocks = GameMod.PrimaryBlocks?.ToList() ?? new List<Block>();
			GlobalGameRules = GameMod.PrimaryRules?.ToList() ?? new List<IRule>();
			ProjectileAliveCondition = GameMod.ProjectileAliveCondition;

			Projectiles = new List<IProjectile>();

			GameActionProvider = new DefaultGameActionProvider(this);

			Players = new List<Player>();
			var shapes = gameMod.GetPlayerFields(playerIds);
			var catapults = gameMod.GetPlayerCatapults(playerIds);
			foreach (string id in playerIds) {
				Player player = new Player(id);
				player.CatapultPosition = catapults.Where(x => x.Key == id).First().Value;
				player.OwnAreas = shapes.Where(x => x.Key == id).Select(x => x.Value).ToList();
			}
		}

		/// <summary>
		/// updating game state
		/// </summary>
		public virtual void Update() {
			Projectiles = Projectiles.Where(x => ProjectileAliveCondition.IsAlive(this, x)).ToList();
			List<IProjectile> localProjectiles = Projectiles.ToList();
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
