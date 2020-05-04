using static System.Math;

namespace Sbazuo.Geometry {
	public struct Segment2D {

		/// <summary>
		/// gets or sets start of this segment
		/// </summary>
		public Point2D A { get; set; }

		/// <summary>
		/// gets or sets end of this segment
		/// </summary>
		public Point2D B { get; set; }

		/// <summary>
		/// returns length of this segment
		/// </summary>
		public double Length => Sqrt(Pow(A.X - B.X, 2) + Pow(A.Y - B.Y, 2));

		/// <summary>
		/// create new instance of <see cref="Segment2D"/>
		/// </summary>
		/// <param name="a"> start of segment </param>
		/// <param name="b"> end of segment </param>
		public Segment2D(Point2D a, Point2D b) {
			this.A = a;
			this.B = b;
		}

	}
}
