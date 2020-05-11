using Sbazuo.Geometry;

namespace Sbazuo.Engine.Blocks {
	public interface IBlockFactory {

		Block CreateBlock(string ownerId, string blockId, Shape2D shape);

	}
}
