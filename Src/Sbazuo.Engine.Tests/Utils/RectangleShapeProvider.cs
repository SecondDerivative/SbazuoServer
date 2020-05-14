using Sbazuo.Engine.Shapes;
using Sbazuo.Geometry;

namespace Sbazuo.Engine.Tests.Utils {
	internal class RectangleShapeProvider : IShapeProvider {

		public double Width { get; set; }

		public double Height { get; set; }

		public RectangleShapeProvider(double width, double height) {
			this.Width = width;
			this.Height = height;
		}

		public Shape2D GetShape(Point2D position, string shapeId) {
			return new Shape2D(new Point2D[] { 
				position, 
				position + new Vector2D(Width, 0), 
				position + new Vector2D(Width, Height), 
				position + new Vector2D(0, Height) 
			});
		}
	}
}
