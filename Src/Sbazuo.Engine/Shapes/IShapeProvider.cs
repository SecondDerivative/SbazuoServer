using Sbazuo.Geometry;

namespace Sbazuo.Engine.Shapes {

	/// <summary>
	/// interface for shape providers
	/// </summary>
	public interface IShapeProvider {

		/// <summary>
		/// returns new instance of <see cref="Shape2D"/>
		/// </summary>
		/// <param name="position"> shape position </param>
		/// <param name="shapeId"> shape unique id </param>
		/// <returns></returns>
		Shape2D GetShape(Point2D position, string shapeId);

	}
}
