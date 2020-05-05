using static System.Math;

namespace Sbazuo.Geometry {
	public struct Vector2D {

		/// <summary>
		/// gets or sets vector X coordinate
		/// </summary>
		public double X { get; set; }

		/// <summary>
		/// gets or sets vector Y coordinate
		/// </summary>
		public double Y { get; set; }

		/// <summary>
		/// returns length of this vector
		/// </summary>
		public double Length => Sqrt(X * X + Y * Y);

		/// <summary>
		/// returns normalized vector of this instance
		/// </summary>
		public Vector2D Normalized => Length == 0 ? new Vector2D(0, 0) : new Vector2D(this.X / this.Length, this.Y / this.Length);

		/// <summary>
		/// returns normal of this vector
		/// </summary>
		public Vector2D Normal => new Vector2D(-Y, X);

		/// <summary>
		/// create new instance of <see cref="Vector2D"/>
		/// </summary>
		/// <param name="x"> X coordinate </param>
		/// <param name="y"> Y coordinate </param>
		public Vector2D(double x, double y) {
			this.X = x;
			this.Y = y;
		}

		/// <summary>
		/// create new instance of <see cref="Vector2D"/>
		/// </summary>
		/// <param name="a"> begins of vector </param>
		/// <param name="b"> ends of vector </param>
		public Vector2D(Point2D a, Point2D b) {
			this.X = b.X - a.X;
			this.Y = b.Y - a.Y;
		}

		/// <summary>
		/// returns new vector, rotated by angle
		/// </summary>
		/// <param name="angle"> rotation angle (radians) </param>
		public Vector2D GetRotatedVector(double angle) {
			return new Vector2D(X * Cos(angle) - Y * Sin(angle), X * Sin(angle) + Y * Cos(angle));
		}

		/// <summary>
		/// calculates math sum of vectors
		/// </summary>
		public static Vector2D operator +(Vector2D a, Vector2D b) {
			return new Vector2D(a.X + b.X, a.Y + b.Y);
		}

		/// <summary>
		/// calculates math substraction of vectors
		/// </summary>
		public static Vector2D operator -(Vector2D a, Vector2D b) {
			return new Vector2D(a.X - b.X, a.Y - b.Y);
		}

		/// <summary>
		/// calculates scalar product of vectors
		/// </summary>
		public static double ScalarProduct(Vector2D a, Vector2D b) {
			return a.X * b.X + a.Y * b.Y;
		}

		/// <summary>
		/// returns a new <see cref="Vector2D"/>, which multiphied on b
		/// </summary>
		public static Vector2D operator *(Vector2D a, double b) {
			return new Vector2D(a.X * b, a.Y * b);
		}

		/// <summary>
		/// returns a new <see cref="Point2D"/>, which standing in the distance of vector direction
		/// </summary>
		public static Point2D operator +(Point2D a, Vector2D direction) {
			return new Point2D(a.X + direction.X, a.Y + direction.Y);
		}

		/// <summary>
		/// calculates vector product of vectors
		/// </summary>
		public static double VectorProduct(Vector2D a, Vector2D b) {
			return a.X * b.Y - a.Y * b.X;
		}

		/// <summary>
		/// calculates angle behind vectors
		/// </summary>
		public static double GetAngle(Vector2D a, Vector2D b) {
			return Atan2(Vector2D.VectorProduct(a, b), Vector2D.ScalarProduct(a, b));
		}

		/// <summary>
		/// returns true, if vectors are collinear
		/// </summary>
		public static bool AreCollinear(Vector2D a, Vector2D b) {
			Vector2D aNorm = a.Normalized;
			Vector2D bNorm = b.Normalized;
			return (aNorm.X == bNorm.X) && (aNorm.Y == bNorm.Y);
		}

		/// <summary>
		/// returns true, if vectors are parallel
		/// </summary>
		public static bool AreParallel(Vector2D a, Vector2D b) {
			return Vector2D.AreCollinear(a, b) || Vector2D.AreCollinear(a, (b * -1));
		}
	}
}
