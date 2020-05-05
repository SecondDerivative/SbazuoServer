using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sbazuo.Geometry.Tests {

	[TestClass]
	public class Vector2DTests {

		private const double Eps = 0.00001;

		[TestMethod]
		public void CreationTest() {
			Vector2D testInstance = new Vector2D(10, 6);
			Assert.AreEqual(testInstance.X, 10);
			Assert.AreEqual(testInstance.Y, 6);
			testInstance = new Vector2D(-1.5, 8.4);
			Assert.AreEqual(testInstance.X, -1.5);
			Assert.AreEqual(testInstance.Y, 8.4);
		}

		[TestMethod]
		public void LengthTest() {
			Vector2D testInstance = new Vector2D(1, 1);
			Assert.AreEqual(testInstance.Length, Math.Sqrt(2));
			testInstance = new Vector2D(1, -1);
			Assert.AreEqual(testInstance.Length, Math.Sqrt(2));
			testInstance = new Vector2D(0, 244.56);
			Assert.AreEqual(testInstance.Length, 244.56);
			testInstance = new Vector2D(-34.5, 0);
			Assert.AreEqual(testInstance.Length, 34.5);
		}

		[TestMethod]
		public void NormalizedTest() {
			Vector2D testInstance = new Vector2D(1000000, 0);
			Assert.AreEqual(testInstance.Normalized.X, 1);
			Assert.AreEqual(testInstance.Normalized.Y, 0);
			testInstance = new Vector2D(0, 10);
			Assert.AreEqual(testInstance.Normalized.X, 0);
			Assert.AreEqual(testInstance.Normalized.Y, 1);
		}

		[TestMethod]
		public void GetRotatedVectorTest() {
			Vector2D testInstance = new Vector2D(1000, 1000);
			Vector2D rotated45 = testInstance.GetRotatedVector(Math.PI / 4);
			Assert.AreEqual(rotated45.X, 0);
			Assert.AreEqual(rotated45.Normalized.Y, 1);
			Vector2D rotated360 = testInstance.GetRotatedVector(Math.PI * 2);
			Assert.IsTrue(Math.Abs(rotated360.X - 1000) < Eps);
			Assert.IsTrue(Math.Abs(rotated360.Y - 1000) < Eps);
		}

		[TestMethod]
		public void AdditiveTest() {
			Vector2D a = new Vector2D(10, 20);
			Vector2D b = new Vector2D(-10.5, -400);
			Vector2D sum = a + b;
			Assert.AreEqual(sum.X, -0.5);
			Assert.AreEqual(sum.Y, -380);
		}

		[TestMethod]
		public void SubstractTest() {
			Vector2D a = new Vector2D(10, 20);
			Vector2D b = new Vector2D(-10.5, -400);
			Vector2D sum = a - b;
			Assert.AreEqual(sum.X, 20.5);
			Assert.AreEqual(sum.Y, 420);
		}

		[TestMethod]
		public void ScalarProductTest() {
			Vector2D a = new Vector2D(1, 0);
			Vector2D b = new Vector2D(0, -1);
			Assert.AreEqual(Vector2D.ScalarProduct(a, b), 0);
		}

		[TestMethod]
		public void VectorProductTest() {
			Vector2D a = new Vector2D(1, 0);
			Vector2D b = new Vector2D(0, 1);
			Assert.AreEqual(Vector2D.VectorProduct(a, b), 1);
		}

		[TestMethod]
		public void MultiphyTest() {
			Vector2D a = new Vector2D(10, -62.5);
			Vector2D m = a * 2;
			Assert.AreEqual(m.X, 20);
			Assert.AreEqual(m.Y, -125);
		}

		[TestMethod]
		public void GetAngleTest() {
			Vector2D a = new Vector2D(1, 0);
			Vector2D b = new Vector2D(0, 1);
			Assert.AreEqual(Vector2D.GetAngle(a, b), Math.PI / 2);
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
		}
	}
}
