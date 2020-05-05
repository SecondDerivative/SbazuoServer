using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sbazuo.Geometry.Tests {

	[TestClass]
	public class GeometryUtilsTests {

		[TestMethod]
		public void DistanceToLineTest() {
			Assert.AreEqual(GeometryUtils.DistanceToLine(new Point2D(0, 0), new Line2D(new Point2D(1, 18), new Point2D(1, -6))), -1);
			Assert.AreEqual(GeometryUtils.DistanceToLine(new Point2D(1, 4), new Line2D(new Point2D(1, 18), new Point2D(1, -6))), 0);
			//Assert.AreEqual(GeometryUtils.DistanceToLine(new Point2D()))
		}

		[TestMethod]
		public void DistanceToSegmentTest() {
			Assert.AreEqual(GeometryUtils.DistanceToSegment(new Point2D(0, 0), new Segment2D(new Point2D(1, 18), new Point2D(1, -6))), -1);
			Assert.AreEqual(GeometryUtils.DistanceToSegment(new Point2D(0, 1), new Segment2D(new Point2D(1, 0), new Point2D(4, 0))), Math.Sqrt(2));
			Assert.AreEqual(GeometryUtils.DistanceToSegment(new Point2D(0, 0), new Segment2D(new Point2D(1, 0), new Point2D(-1, 0))), 0);
		}

		[TestMethod]
		public void DistanceBetweenSegmentTest() {
			Assert.AreEqual(GeometryUtils.DistanceBetweenSegments(new Segment2D(new Point2D(0, 0), new Point2D(0, 1)), new Segment2D(new Point2D(1, 0), new Point2D(2, 0))), 1);
		}

	}
}
