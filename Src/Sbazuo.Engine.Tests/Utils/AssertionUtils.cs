using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbazuo.Geometry;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sbazuo.Engine.Tests.Utils {
	internal static class AssertionUtils {

		internal static void PointsEqual(Point2D point, double x, double y) {
			Assert.AreEqual(x, point.X, GeometryUtils.Eps);
			Assert.AreEqual(y, point.Y, GeometryUtils.Eps);
		}

	}
}
