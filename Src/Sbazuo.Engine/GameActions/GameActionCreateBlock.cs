using Sbazuo.Engine.GameControls;
using Sbazuo.Geometry;

namespace Sbazuo.Engine.GameActions {

	/// <summary>
	/// represents info about new block creation
	/// </summary>
	public class GameActionCreateBlock : GameAction {

		/// <summary>
		/// unique block id
		/// </summary>
		public readonly string BlockId;

		/// <summary>
		/// unique shape id
		/// </summary>
		public readonly string ShapeId;

		/// <summary>
		/// block position
		/// </summary>
		public readonly Point2D Position;

		/// <summary>
		/// create new instance of <see cref="GameActionCreateBlock"/>
		/// </summary>
		/// <param name="instigatorId"> unique player id </param>
		/// <param name="blockId"> unique block id </param>
		/// <param name="shapeId"> unique shape id </param>
		/// <param name="position"> block position </param>
		public GameActionCreateBlock(string instigatorId, string blockId, string shapeId, Point2D position) : base(instigatorId) {
			this.BlockId = blockId;
			this.ShapeId = shapeId;
			this.Position = position;
		}

		public override void ApplyToGame(GameController controller) {
			controller.Blocks.Add(controller.BlockFactory.CreateBlock(InstigatorId, BlockId, controller.ShapeFactory.CreateShape(Position, ShapeId)));
		}

	}
}
