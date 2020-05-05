using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sbazuo.Geometry.Tests {

	[TestClass]
	public class Shape2DTests {

		[TestMethod]
		public void HasIntersectionTest() {
			Shape2D shape = new Shape2D(new List<Point2D> { new Point2D(-1, 0), new Point2D(1, 0), new Point2D(0, 1) });
			Assert.IsTrue(shape.HasIntersection(new Segment2D(new Point2D(0, 0.5), new Point2D(-200, -400))));
			Assert.IsTrue(shape.HasIntersection(new Segment2D(new Point2D(0, 1), new Point2D(200, 400))));
			Assert.IsFalse(shape.HasIntersection(new Segment2D(new Point2D(0, 1.01), new Point2D(200, 400))));
			Assert.IsFalse(shape.HasIntersection(new Segment2D(new Point2D(-0.1, 0.5), new Point2D(0.1, 0.5))));
		}

		[TestMethod]
		public void ContainsPointTest() {
			Shape2D shape = new Shape2D(new List<Point2D> { new Point2D(-1, 0), new Point2D(1, 0), new Point2D(0, 1) });
			Assert.IsTrue(shape.ContainsPoint(new Point2D(0, 0.5)));
			Assert.IsTrue(shape.ContainsPoint(new Point2D(0.01, 0.01)));
			Assert.IsFalse(shape.ContainsPoint(new Point2D(-2, 0)));
			Assert.IsFalse(shape.ContainsPoint(new Point2D(0, 2)));
			Assert.IsFalse(shape.ContainsPoint(new Point2D(0.51, 0.51)));
		}

	}
}
