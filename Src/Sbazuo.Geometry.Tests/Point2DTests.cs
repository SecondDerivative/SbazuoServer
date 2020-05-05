using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sbazuo.Geometry.Tests {

	[TestClass]
	public class Point2DTests {

		[TestMethod]
		public void CreationTest() {
			Point2D testInstance = new Point2D(10, -5.5);
			Assert.AreEqual(10, testInstance.X);
			Assert.AreEqual(-5.5, testInstance.Y);
		}

		[TestMethod]
		public void DistanceTest() {
			Point2D a = new Point2D(10, 0);
			Point2D b = new Point2D(0, 10);
			Assert.AreEqual(Math.Sqrt(2) * 10, Point2D.Distance(a, b), GeometryUtils.Eps);
		}

	}
}
