﻿using Sbazuo.Engine.Blocks;
using Sbazuo.Engine.GameActions;
using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.GameRules;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Engine.Projectiles.AliveConditions;
using Sbazuo.Engine.Shapes;
using Sbazuo.Engine.Triggers;
using Sbazuo.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sbazuo.Engine.GameMods {

	/// <summary>
	/// represents realtime game mod
	/// </summary>
	public class RealTimeGameMod : IGameMod {

		public virtual IEnumerable<Block> PrimaryBlocks => null;

		public virtual IEnumerable<IRule> PrimaryRules => null;

		public virtual IEnumerable<ITrigger> PrimaryTriggers => null;

		public virtual IProjectileAliveCondition ProjectileAliveCondition => new ProjectileAliveConditionContainer {
			new HealthAliveCondition(),
			new InnerGameFieldAliveCondition(),
			new MotionAliveCondition()
		};

		public virtual int MaxPlayers => 4;

		public virtual int MinPlayers => 2;

		public virtual IProjectileFactory ProjectileFactory => new DefaultProjectileFactory();

		public virtual IBlockFactory BlockFactory => new DefaultBlockFactory();

		public virtual IShapeProvider ShapeProvider => new DefaultShapeProvider();

		public virtual Shape2D GameField => new Shape2D(new Point2D[] { new Point2D(0, 0), new Point2D(GameFieldWidth, 0), new Point2D(GameFieldWidth, GameFieldHeight), new Point2D(0, GameFieldHeight) });

		public readonly int GameFieldWidth;

		public readonly int GameFieldHeight;

		public virtual IEnumerable<KeyValuePair<string, Point2D>> GetPlayerCatapults(IEnumerable<string> playerIds) {
			int playerCount = playerIds.Count();
			if (playerCount < MinPlayers || playerCount > MaxPlayers) {
				throw new ArgumentException("incorrect players count");
			}
			// 1/4 part of width
			int w14 = GameFieldWidth / 4;
			// 3/4 part of width
			int w34 = GameFieldWidth / 2 + w14;
			// 1/4 part of height
			int h14 = GameFieldHeight / 4;
			// 3/4 part of height
			int h34 = GameFieldHeight / 2 + h14;

			string[] ids = playerIds.ToArray();
			Point2D[] points = new Point2D[] { new Point2D(w14, h14), new Point2D(w14, h34), new Point2D(w34, h14), new Point2D(w34, h34) };
			ICollection<KeyValuePair<string, Point2D>> result = new List<KeyValuePair<string, Point2D>>();
			for (int i = 0; i < playerCount; ++i) {
				result.Add(new KeyValuePair<string, Point2D>(ids[i], points[i]));
			}
			return result;
		}

		public virtual IEnumerable<KeyValuePair<string, Shape2D>> GetPlayerFields(IEnumerable<string> playerIds) {
			int playerCount = playerIds.Count();
			if (playerCount < MinPlayers || playerCount > MaxPlayers) {
				throw new ArgumentException("incorrect players count");
			}

			string[] ids = playerIds.ToArray();
			Shape2D[] shapes = new Shape2D[] { 
				new Shape2D(new Point2D[] { new Point2D(0, 0), new Point2D(GameFieldWidth / 2, 0), new Point2D(GameFieldWidth / 2, GameFieldHeight / 2), new Point2D(0, GameFieldHeight / 2) }),
				new Shape2D(new Point2D[] { new Point2D(0, GameFieldHeight / 2), new Point2D(GameFieldWidth / 2, GameFieldHeight / 2), new Point2D(GameFieldWidth / 2, GameFieldHeight), new Point2D(0, GameFieldHeight) }),
				new Shape2D(new Point2D[] { new Point2D(GameFieldWidth / 2, 0), new Point2D(GameFieldWidth, 0), new Point2D(GameFieldWidth, GameFieldHeight / 2), new Point2D(GameFieldWidth / 2, GameFieldHeight / 2) }),
				new Shape2D(new Point2D[] { new Point2D(GameFieldWidth / 2, GameFieldHeight / 2), new Point2D(GameFieldWidth, GameFieldHeight / 2), new Point2D(GameFieldWidth, GameFieldHeight), new Point2D(GameFieldWidth / 2, GameFieldHeight) })
			};
			ICollection<KeyValuePair<string, Shape2D>> result = new List<KeyValuePair<string, Shape2D>>();
			for (int i = 0; i < playerCount; ++i) {
				result.Add(new KeyValuePair<string, Shape2D>(ids[i], shapes[i]));
			}
			return result;
		}

		public virtual bool ValidateGameAction(GameController controller, GameAction action) {
			return true;
		}

		public virtual void Init(GameController controller) {
			
		}

		/// <summary>
		/// create new instance of <see cref="RealTimeGameMod"/>
		/// </summary>
		/// <param name="fieldWidth"></param>
		/// <param name="fieldHeight"></param>
		public RealTimeGameMod(int fieldWidth, int fieldHeight) {
			GameFieldWidth = fieldWidth;
			GameFieldHeight = fieldHeight;
		}

	}
}
