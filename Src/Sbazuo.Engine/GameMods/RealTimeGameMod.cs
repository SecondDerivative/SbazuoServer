using Sbazuo.Engine.Blocks;
using Sbazuo.Engine.GameActions;
using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.GameRules;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Engine.Projectiles.AliveConditions;
using Sbazuo.Geometry;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sbazuo.Engine.GameMods {

	/// <summary>
	/// represents realtime game mod
	/// </summary>
	public class RealTimeGameMod : IGameMod {

		public IEnumerable<Block> PrimaryBlocks => throw new NotImplementedException();

		public IEnumerable<IRule> PrimaryRules => throw new NotImplementedException();

		public IProjectileAliveCondition ProjectileAliveCondition => throw new NotImplementedException();

		public int MaxPlayers => 4;

		public int MinPlayers => 2;

		public IProjectileFactory ProjectileFactory => new DefaultProjectileFactory();

		public IBlockFactory BlockFactory => new DefaultBlockFactory();

		public Shape2D GameField => new Shape2D(new Point2D[] { new Point2D(0, 0), new Point2D(400, 0), new Point2D(400, 300), new Point2D(0, 300) });

		public IEnumerable<KeyValuePair<string, Point2D>> GetPlayerCatapults(int playerCount) {
			//Point2D[] fullArray = new Point2D[] { new Point2D(), new Point2D(), new Point2D(), new Point2D() };
			throw new NotImplementedException();
		}

		public IEnumerable<KeyValuePair<string, Shape2D>> GetPlayerFields(int playerCount) {
			throw new NotImplementedException();
		}

		public bool ValidateGameAction(GameController controller, GameAction action) {
			return true;
		}
	}
}
