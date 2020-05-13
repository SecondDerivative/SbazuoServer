using Sbazuo.Geometry;

namespace Sbazuo.Engine.Blocks {

	/// <summary>
	/// represents default instance of <see cref="IBlockFactory"/>
	/// </summary>
	public class DefaultBlockFactory : IBlockFactory {

		public Block CreateBlock(string ownerId, string blockId, string shapeId, Point2D position) {
			return new PhysicalBlock(ownerId, shapeId, position, 100);
		}
	}
}
