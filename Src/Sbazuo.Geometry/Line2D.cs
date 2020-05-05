namespace Sbazuo.Geometry {
	public struct Line2D {

		/// <summary>
		/// gets or sets point, which line contains
		/// </summary>
		public Point2D LinePoint { get; set; }

		/// <summary>
		/// gets or sets vector, which parallel with line
		/// </summary>
		public Vector2D Direction { get; set; }

		/// <summary>
		/// create new instance of <see cref="Line2D"/>, using linePoint and direction vector
		/// </summary>
		public Line2D(Point2D linePoint, Vector2D lineDirection) {
			this.LinePoint = linePoint;
			this.Direction = lineDirection;
		}

		/// <summary>
		/// create new instance of <see cref="Line2D"/>, using points
		/// </summary>
		public Line2D(Point2D a, Point2D b) {
			this.LinePoint = a;
			this.Direction = new Vector2D(a, b);
		}

		/// <summary>
		/// create new instance of <see cref="Line2D"/>, using ends of <see cref="Segment2D"/>
		/// </summary>
		public Line2D(Segment2D prototype) {
			this.LinePoint = prototype.A;
			this.Direction = new Vector2D(prototype.A, prototype.B);
		}

	}
}
