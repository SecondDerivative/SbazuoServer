using Sbazuo.Geometry;

namespace Sbazuo.Engine.Shapes {
	public class DefaultShapeProvider : IShapeProvider {

		public Shape2D GetShape(Point2D position, string shapeId) {
			return new Shape2D(new Point2D[] {
				position,
				position + new Vector2D(0, 20),
				position + new Vector2D(20, 20),
				position + new Vector2D(20, 0)
			});
		}

	}
}
