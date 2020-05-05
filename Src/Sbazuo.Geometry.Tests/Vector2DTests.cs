using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sbazuo.Geometry.Tests {

	[TestClass]
	public class Vector2DTests {

		[TestMethod]
		public void CreationTest() {
			Vector2D testInstance = new Vector2D(10, 6);
			Assert.AreEqual(10, testInstance.X);
			Assert.AreEqual(6, testInstance.Y);
			testInstance = new Vector2D(-1.5, 8.4);
			Assert.AreEqual(-1.5, testInstance.X);
			Assert.AreEqual(8.4, testInstance.Y);
			Point2D a = new Point2D(10, 0);
			Point2D b = new Point2D(0, 6);
			testInstance = new Vector2D(a, b);
			Assert.AreEqual(-10, testInstance.X);
			Assert.AreEqual(6, testInstance.Y);
		}

		[TestMethod]
		public void LengthTest() {
			Vector2D testInstance = new Vector2D(1, 1);
			Assert.AreEqual(Math.Sqrt(2), testInstance.Length, GeometryUtils.Eps);
			testInstance = new Vector2D(1, -1);
			Assert.AreEqual(Math.Sqrt(2), testInstance.Length, GeometryUtils.Eps);
			testInstance = new Vector2D(0, 244.56);
			Assert.AreEqual(244.56, testInstance.Length);
			testInstance = new Vector2D(-34.5, 0);
			Assert.AreEqual(34.5, testInstance.Length);
		}

		[TestMethod]
		public void NormalizedTest() {
			Vector2D testInstance = new Vector2D(1000000, 0);
			Assert.AreEqual(1, testInstance.Normalized.X);
			Assert.AreEqual(0, testInstance.Normalized.Y);
			testInstance = new Vector2D(0, 10);
			Assert.AreEqual(0, testInstance.Normalized.X);
			Assert.AreEqual(1, testInstance.Normalized.Y);
		}

		[TestMethod]
		public void GetRotatedVectorTest() {
			Vector2D testInstance = new Vector2D(1000, 1000);
			Vector2D rotated45 = testInstance.GetRotatedVector(Math.PI / 4);
			Assert.AreEqual(rotated45.X, 0);
			Assert.AreEqual(rotated45.Normalized.Y, 1);
			Vector2D rotated360 = testInstance.GetRotatedVector(Math.PI * 2);
			Assert.AreEqual(1000, rotated360.X, GeometryUtils.Eps);
			Assert.AreEqual(1000, rotated360.Y, GeometryUtils.Eps);
		}

		[TestMethod]
		public void AdditiveTest() {
			Vector2D a = new Vector2D(10, 20);
			Vector2D b = new Vector2D(-10.5, -400);
			Vector2D sum = a + b;
			Assert.AreEqual(-0.5, sum.X);
			Assert.AreEqual(-380, sum.Y);
		}

		[TestMethod]
		public void SubstractTest() {
			Vector2D a = new Vector2D(10, 20);
			Vector2D b = new Vector2D(-10.5, -400);
			Vector2D sum = a - b;
			Assert.AreEqual(20.5, sum.X);
			Assert.AreEqual(420, sum.Y);
		}

		[TestMethod]
		public void ScalarProductTest() {
			Vector2D a = new Vector2D(1, 0);
			Vector2D b = new Vector2D(0, -1);
			Assert.AreEqual(0, Vector2D.ScalarProduct(a, b));
		}

		[TestMethod]
		public void VectorProductTest() {
			Vector2D a = new Vector2D(1, 0);
			Vector2D b = new Vector2D(0, 1);
			Assert.AreEqual(1, Vector2D.VectorProduct(a, b));
			a = new Vector2D(1, 1);
			b = new Vector2D(-1, 1);
			Assert.AreEqual(2, Vector2D.VectorProduct(a, b));
		}

		[TestMethod]
		public void MultiphyTest() {
			Vector2D a = new Vector2D(10, -62.5);
			Vector2D m = a * 2;
			Assert.AreEqual(m.X, 20);
			Assert.AreEqual(m.Y, -125);
			m *= 0.5;
			Assert.AreEqual(m.X, a.X);
			Assert.AreEqual(m.Y, a.Y);
		}

		[TestMethod]
		public void GetAngleTest() {
			Vector2D a = new Vector2D(1, 0);
			Vector2D b = new Vector2D(0, 1);
			Assert.AreEqual(Math.PI / 2, Vector2D.GetAngle(a, b), GeometryUtils.Eps);
			Assert.AreEqual(Math.PI / 2, Math.Abs(Vector2D.GetAngle(a, a.Normal)), GeometryUtils.Eps);
		}

		[TestMethod]
		public void AreCollinearTest() {
			Vector2D a = new Vector2D(10, 5.5);
			Vector2D b = new Vector2D(200, 110);
			Vector2D c = new Vector2D(-10, -5.5);
			Vector2D d = new Vector2D(14, 6);
			Assert.IsTrue(Vector2D.AreCollinear(a, b));
			Assert.IsFalse(Vector2D.AreCollinear(a, c));
			Assert.IsFalse(Vector2D.AreCollinear(b, c));
			Assert.IsFalse(Vector2D.AreCollinear(a, d));
			Assert.IsFalse(Vector2D.AreCollinear(b, d));
		}

		[TestMethod]
		public void AreParallelTest() {
			Vector2D a = new Vector2D(10, 5.5);
			Vector2D b = new Vector2D(200, 110);
			Vector2D c = new Vector2D(-10, -5.5);
			Vector2D d = new Vector2D(14, 6);
			Assert.IsTrue(Vector2D.AreParallel(a, b));
			Assert.IsTrue(Vector2D.AreParallel(a, c));
			Assert.IsTrue(Vector2D.AreParallel(b, c));
			Assert.IsFalse(Vector2D.AreParallel(a, d));
			Assert.IsFalse(Vector2D.AreParallel(b, d));

			Assert.IsFalse(Vector2D.AreParallel(new Vector2D(0, 1), new Vector2D(0.0001, 2)));
		}

		[TestMethod]
		public void MovePointTest() {
			Point2D p = new Point2D(5, 3);
			Vector2D dir = new Vector2D(-15, 6);
			Point2D result = p + dir;
			Assert.AreEqual(-10, result.X);
			Assert.AreEqual(9, result.Y);
		}
	}
}
