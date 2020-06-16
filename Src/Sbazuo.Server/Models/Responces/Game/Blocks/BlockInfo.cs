using Sbazuo.Server.Models.Game;

namespace Sbazuo.Server.Models.Responces.Game.Blocks {
	public abstract class BlockInfo {

		public string BlockId { get; set; }

		public string ShapeId { get; set; }

		public string OwnerId { get; set; }

		public Point ShapePosition { get; set; }

	}
}
