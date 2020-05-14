using Sbazuo.Geometry;

namespace Sbazuo.Engine.Blocks {
	public interface IBlockFactory {

		Block CreateBlock(string ownerId, string blockId, string shapeId, Point2D position);

	}
}
