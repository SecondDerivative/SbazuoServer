using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sbazuo.Geometry.Tests {

	[TestClass]
	public class GeometryUtilsTests {

		[TestMethod]
		public void DistanceToLineTest() {
			Assert.AreEqual(-1, GeometryUtils.DistanceToLine(new Point2D(0, 0), new Line2D(new Point2D(1, 18), new Point2D(1, -6))));
			Assert.AreEqual(0, GeometryUtils.DistanceToLine(new Point2D(1, 4), new Line2D(new Point2D(1, 18), new Point2D(1, -6))));
			Assert.AreEqual(0, GeometryUtils.DistanceToLine(new Point2D(1, 18), new Line2D(new Point2D(1, 18), new Point2D(1, -6))));
		}

		[TestMethod]
		public void DistanceToSegmentTest() {
			Assert.AreEqual(-1, GeometryUtils.DistanceToSegment(new Point2D(0, 0), new Segment2D(new Point2D(1, 18), new Point2D(1, -6))));
			Assert.AreEqual(Math.Sqrt(2), GeometryUtils.DistanceToSegment(new Point2D(0, 1), new Segment2D(new Point2D(1, 0), new Point2D(4, 0))), GeometryUtils.Eps);
			Assert.AreEqual(0, GeometryUtils.DistanceToSegment(new Point2D(0, 0), new Segment2D(new Point2D(1, 0), new Point2D(-1, 0))));
		}

		[TestMethod]
		public void DistanceBetweenSegmentTest() {
			Assert.AreEqual(1, GeometryUtils.DistanceBetweenSegments(new Segment2D(new Point2D(0, 0), new Point2D(0, 1)), new Segment2D(new Point2D(1, 0), new Point2D(2, 0))));
			Assert.AreEqual(0, GeometryUtils.DistanceBetweenSegments(new Segment2D(new Point2D(0, 1), new Point2D(2, -1)), new Segment2D(new Point2D(1, 0), new Point2D(1, 1))));
			Assert.AreEqual(0, GeometryUtils.DistanceBetweenSegments(new Segment2D(new Point2D(0, 0), new Point2D(1, 1)), new Segment2D(new Point2D(1, 0), new Point2D(0, 1))));
		}

		[TestMethod]
		public void DistanceBetweenLinesTest() {
			Assert.AreEqual(0, GeometryUtils.DistanceBetweenLines(new Line2D(new Point2D(-10000000, 0), new Vector2D(0.0001, 1)), new Line2D(new Point2D(10000000, 0), new Vector2D(0.00001, 1))));
			Assert.AreEqual(2, GeometryUtils.DistanceBetweenLines(new Line2D(new Point2D(-1, -60000), new Vector2D(0, 1)), new Line2D(new Point2D(1, 0), new Vector2D(0, 1))));
			Assert.AreEqual(1, Math.Abs(GeometryUtils.DistanceBetweenLines(new Line2D(new Point2D(0, 0), new Vector2D(1, 0)), new Line2D(new Point2D(0, 1), new Vector2D(1, 0)))));
		}

		[TestMethod]
		public void DistanceFromSegmentToLineTest() {
			Assert.AreEqual(1, Math.Abs(GeometryUtils.DistanceFromSegmentToLine(new Segment2D(new Point2D(0, 0), new Point2D(-1, -1)), new Line2D(new Point2D(1, -60000), new Vector2D(0, 1)))));
			Assert.AreEqual(0, GeometryUtils.DistanceFromSegmentToLine(new Segment2D(new Point2D(0, 0), new Point2D(-1, -1)), new Line2D(new Point2D(-25000, -25000), new Vector2D(-1, -1))));
			Assert.AreEqual(0, GeometryUtils.DistanceFromSegmentToLine(new Segment2D(new Point2D(0, 0), new Point2D(-1, -1)), new Line2D(new Point2D(0, 0), new Vector2D(-1, -1))));
		}

		[TestMethod]
		public void DistanceFromSegmentToRayTest() {
			Assert.AreEqual(0, GeometryUtils.DistanceFromSegmentToRay(new Segment2D(new Point2D(-1, 1), new Point2D(1, -1)), new Ray2D(new Point2D(0, 0), new Vector2D(1, 1))));
			Assert.AreEqual(0, GeometryUtils.DistanceFromSegmentToRay(new Segment2D(new Point2D(-1, 1), new Point2D(1, -1)), new Ray2D(new Point2D(20, -20), new Vector2D(-1, 1))));
			Assert.AreEqual(1, GeometryUtils.DistanceFromSegmentToRay(new Segment2D(new Point2D(-1, 0), new Point2D(1, 0)), new Ray2D(new Point2D(0, 1), new Vector2D(0, 1))));
			Assert.AreEqual(0, GeometryUtils.DistanceFromSegmentToRay(new Segment2D(new Point2D(-1, 0), new Point2D(1, 0)), new Ray2D(new Point2D(0, 1), new Vector2D(0, -1))));
			Assert.AreEqual(0, GeometryUtils.DistanceFromSegmentToRay(new Segment2D(new Point2D(1, 0), new Point2D(0, 1)), new Ray2D(new Point2D(0, 0), new Vector2D(1, 1))));
		}

	}
}
