using Sbazuo.Engine.Blocks;
using Sbazuo.Engine.GameActions;
using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.GameRules;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Engine.Projectiles.AliveConditions;
using Sbazuo.Engine.Shapes;
using Sbazuo.Engine.Triggers;
using System.Collections.Generic;

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

		public virtual bool ValidateGameAction(GameController controller, GameAction action) {
			return true;
		}

		public virtual void Init(GameController controller) {
			
		}

		/// <summary>
		/// create new instance of <see cref="RealTimeGameMod"/>
		/// </summary>
		public RealTimeGameMod() {
			
		}

	}
}
