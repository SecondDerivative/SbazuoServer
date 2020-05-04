using static System.Math;

namespace Sbazuo.Geometry {
	public static class GeometryUtils {

		/// <summary>
		/// calculates distance from <see cref="Point2D"/> to <see cref="Line2D" />
		/// </summary>
		public static double DistanceToLine(Point2D point, Line2D line) {
			Vector2D n = line.LineDirection.Normal;
			Vector2D x = new Vector2D(line.LinePoint, point);
			return Vector2D.ScalarProduct(n, x) / n.Length;
		}

		/// <summary>
		/// calculates distance from <see cref="Point2D"/> to <see cref="Segment2D"/>
		/// </summary>
		public static double DistanceToSegment(Point2D point, Segment2D segment) {
			Vector2D bc = new Vector2D(segment.A, segment.B);
			Vector2D ba = new Vector2D(segment.A, point);
			Vector2D ca = new Vector2D(segment.B, point);
			double result = Min(Point2D.Distance(point, segment.A), Point2D.Distance(point, segment.B));
			if (Abs(Vector2D.GetAngle(bc, ba)) < PI / 2 && Abs(Vector2D.GetAngle(ca, bc * -1)) < PI / 2) {
				result = Min(result, DistanceToLine(point, new Line2D(segment)));
			}
			return result;
		}


		/// <summary>
		/// calculates distance between two segments
		/// </summary>
		public static double DistanceBetweenSegments(Segment2D a, Segment2D b) {
			double result = Min(Min(Point2D.Distance(a.A, b.A), Point2D.Distance(a.A, b.B)), Min(Point2D.Distance(a.B, b.A), Point2D.Distance(a.B, b.B)));
			double result2 = Min(Min(Abs(DistanceToSegment(a.A, b)), Abs(DistanceToSegment(a.B, b))), Min(Abs(DistanceToSegment(b.A, a)), Abs(DistanceToSegment(b.B, a))));
			result = Min(result, result2);
			if (Sign(DistanceToLine(a.A, new Line2D(b))) != Sign(DistanceToLine(a.B, new Line2D(b))) && Sign(DistanceToLine(b.A, new Line2D(a))) != Sign(DistanceToLine(b.B, new Line2D(a)))) {
				return 0;
			}
			return result;
		}

		/// <summary>
		/// calculates distance between two lines
		/// </summary>
		public static double DistanceBetweenLines(Line2D a, Line2D b) {
			if (Vector2D.AreParallel(a.LineDirection, b.LineDirection)) {
				return DistanceToLine(a.LinePoint, b);
			}
			return 0;
		}

		/// <summary>
		/// calculates distance from <see cref="Segment2D"/> to <see cref="Line2D"/>
		/// </summary>
		public static double DistanceFromSegmentToLine(Segment2D segment, Line2D line) {
			double result = Min(Point2D.Distance(segment.A, line.LinePoint), Point2D.Distance(segment.B, line.LinePoint));
			//Vector2D ca = new Vector2D(line.LinePoint, segment.A);
			//Vector2D cb = new Vector2D(line.LinePoint, segment.B);
			result = Min(result, Abs(DistanceToLine(segment.B, line)));
			result = Min(result, Abs(DistanceToLine(segment.A, line)));
			if (Sign(DistanceToLine(segment.A, line)) != Sign(DistanceToLine(segment.B, line))) {
				return 0;
			}
			return result;
		}

	}
}
