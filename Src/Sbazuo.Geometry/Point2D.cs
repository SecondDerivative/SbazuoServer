using static System.Math;

namespace Sbazuo.Geometry {
	public struct Point2D {

		/// <summary>
		/// gets or sets point X coordinate
		/// </summary>
		public double X { get; set; }

		/// <summary>
		/// gets or sets point Y coordinate
		/// </summary>
		public double Y { get; set; }

		/// <summary>
		/// create new instance of <see cref="Point2D"/>
		/// </summary>
		/// <param name="x"> point x coordinate </param>
		/// <param name="y"> point y coordinate </param>
		public Point2D(double x, double y) {
			this.X = x;
			this.Y = y;
		}

		/// <summary>
		/// calculates distance of points
		/// </summary>
		public static double Distance(Point2D a, Point2D b) {
			return Sqrt(Pow(a.X - b.X, 2) + Pow(a.Y - b.Y, 2));
		}

	}
}
