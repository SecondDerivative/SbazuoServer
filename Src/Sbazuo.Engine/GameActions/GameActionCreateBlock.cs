using Sbazuo.Engine.GameControls;
using Sbazuo.Geometry;

namespace Sbazuo.Engine.GameActions {

	/// <summary>
	/// represents info about new block creation
	/// </summary>
	public class GameActionCreateBlock : GameAction {

		public readonly string BlockId;

		public readonly Shape2D Shape;

		public GameActionCreateBlock(string instigatorId, string blockId, Shape2D shape) : base(instigatorId) {
			this.BlockId = blockId;
			this.Shape = shape;
		}

		public override void ApplyToGame(GameController controller) {
			controller.Blocks.Add(controller.BlockFactory.CreateBlock(InstigatorId, BlockId, Shape));
		}

	}
}
