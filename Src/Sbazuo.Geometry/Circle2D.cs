namespace Sbazuo.Geometry {

	/// <summary>
	/// represents geomerty circle
	/// </summary>
	public sealed class Circle2D {

		/// <summary>
		/// gets or sets circle center
		/// </summary>
		public Point2D Center { get; set; }

		/// <summary>
		/// gets or sets circle radius
		/// </summary>
		public double Radius { get; set; }

		/// <summary>
		/// create new instance of <see cref="Circle2D"/>
		/// </summary>
		public Circle2D(Point2D center, double radius) {
			this.Center = center;
			this.Radius = radius;
		}

		/// <summary>
		/// returns true if this circle has intersection with shape
		/// </summary>
		public bool HasIntersection(Shape2D shape) {
			return shape.ContainsPoint(Center) || shape.Distance(Center) < Radius;
		}

	}
}
