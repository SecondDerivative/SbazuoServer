using Sbazuo.Engine.Blocks;
using Sbazuo.Engine.GameActions;
using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.GameRules;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Engine.Projectiles.AliveConditions;
using Sbazuo.Engine.Shapes;
using Sbazuo.Engine.Triggers;
using Sbazuo.Geometry;
using System.Collections.Generic;

namespace Sbazuo.Engine.GameMods {

	/// <summary>
	/// represents info about game mod (realtime game, step-by-step game e.t.c.)
	/// </summary>
	public interface IGameMod {

		/// <summary>
		/// gets primary player blocks
		/// </summary>
		IEnumerable<Block> PrimaryBlocks { get; }

		/// <summary>
		/// gets primary game rules
		/// </summary>
		IEnumerable<IRule> PrimaryRules { get; }

		/// <summary>
		/// gets primary game triggers
		/// </summary>
		IEnumerable<ITrigger> PrimaryTriggers { get; }

		/// <summary>
		/// gets projectile alive condition
		/// </summary>
		IProjectileAliveCondition ProjectileAliveCondition { get; }

		/// <summary>
		/// gets maximal players for this game mode
		/// </summary>
		int MaxPlayers { get; }

		/// <summary>
		/// gets minimal players for this game mode 
		/// </summary>
		int MinPlayers { get; }

		/// <summary>
		/// gets projectile factory for this game mode
		/// </summary>
		IProjectileFactory ProjectileFactory { get; }

		/// <summary>
		/// gets block factory for this game mode
		/// </summary>
		IBlockFactory BlockFactory { get; }

		/// <summary>
		/// gets shape provider for this game mode
		/// </summary>
		IShapeProvider ShapeProvider { get; }

		/// <summary>
		/// validating game action applying possibility
		/// </summary>
		/// <param name="controller"></param>
		/// <param name="action"></param>
		/// <returns> true, if game action can be applied </returns>
		bool ValidateGameAction(GameController controller, GameAction action);

		/// <summary>
		/// initialize game mod
		/// </summary>
		/// <param name="controller"></param>
		void Init(GameController controller);

	}
}
