using System;
using System.Collections.Generic;
using System.Linq;

namespace Sbazuo.Geometry {

	/// <summary>
	/// represents data of geometrical shape
	/// </summary>
	public sealed class Shape2D {

		private readonly List<Point2D> ShapePoints;

		public IEnumerable<Point2D> Points => ShapePoints;

		/// <summary>
		/// returns all segments, which constituents this shape
		/// </summary>
		public IEnumerable<Segment2D> Segments => GetSegments();

		/// <summary>
		/// create new instance of <see cref="Shape2D"/>, using points
		/// </summary>
		public Shape2D(IEnumerable<Point2D> points) {
			this.ShapePoints = points.ToList();
		}

		/// <summary>
		/// returns true, if segment has intersection with figure
		/// </summary>
		/// <param name="segment"></param>
		public bool HasIntersection(Segment2D segment) {
			foreach (var s in Segments) {
				if (GeometryUtils.DistanceBetweenSegments(segment, s) == 0) {
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// returns true, if this shape include point
		/// </summary>
		public bool ContainsPoint(Point2D point) {
			double randomAngle = 1.4585381;
			Ray2D testRay = new Ray2D(point, new Vector2D(1, 0).GetRotatedVector(randomAngle));
			int intersections = 0;
			foreach (var s in Segments) {
				if (GeometryUtils.DistanceFromSegmentToRay(s, testRay) == 0) {
					++intersections;
				}
			}
			return intersections % 2 == 1;
		}

		private List<Segment2D> GetSegments() {
			List<Segment2D> result = new List<Segment2D>();
			for (int i = 1; i < ShapePoints.Count; ++i) {
				result.Add(new Segment2D(ShapePoints[i - 1], ShapePoints[i]));
			}
			result.Add(new Segment2D(ShapePoints[ShapePoints.Count - 1], ShapePoints[0]));
			return result;
		}

		/// <summary>
		/// returns distance from <see cref="Point2D"/> to this shape
		/// </summary>
		public double Distance(Point2D point) {
			double result = GeometryUtils.Infinity;
			foreach (var s in Segments) {
				result = Math.Min(Math.Abs(GeometryUtils.DistanceToSegment(point, s)), result);
			}
			return result;
		}

	}
}
