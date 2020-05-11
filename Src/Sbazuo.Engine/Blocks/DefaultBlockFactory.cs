using Sbazuo.Geometry;

namespace Sbazuo.Engine.Blocks {


	public class DefaultBlockFactory : IBlockFactory {
		public Block CreateBlock(string ownerId, string blockId, Shape2D shape) {
			return new PhysicalBlock(ownerId, shape, 100);
		}
	}
}
