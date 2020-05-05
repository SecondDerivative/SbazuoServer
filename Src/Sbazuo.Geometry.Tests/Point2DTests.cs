using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sbazuo.Geometry.Tests {

	[TestClass]
	public class Point2DTests {

		[TestMethod]
		public void CreationTest() {
			Point2D testInstance = new Point2D(10, -5.5);
			Assert.AreEqual(testInstance.X, 10);
			Assert.AreEqual(testInstance.Y, -5.5);
		}

		[TestMethod]
		public void DistanceTest() {
			Point2D a = new Point2D(10, 0);
			Point2D b = new Point2D(0, 10);
			Assert.AreEqual(Point2D.Distance(a, b), Math.Sqrt(2) * 10);
		}

	}
}
