namespace Sbazuo.Geometry {
	public struct Ray2D {

		/// <summary>
		/// gets or sets ray start point
		/// </summary>
		public Point2D StartPoint { get; set; }

		/// <summary>
		/// gets or sets ray direction vector
		/// </summary>
		public Vector2D RayDirection { get; set; }

		/// <summary>
		/// create new instance of <see cref="Ray2D"/>, using start point and direction vector
		/// </summary>
		public Ray2D(Point2D startPoint, Vector2D direction) {
			this.StartPoint = startPoint;
			this.RayDirection = direction;
		}

		/// <summary>
		/// create new instance of <see cref="Ray2D"/>, using points
		/// </summary>
		public Ray2D(Point2D a, Point2D b) {
			this.StartPoint = a;
			this.RayDirection = new Vector2D(a, b);
		}

	}
}
