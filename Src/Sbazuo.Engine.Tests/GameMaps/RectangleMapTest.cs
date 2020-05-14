using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbazuo.Engine.GameMaps;
using Sbazuo.Engine.Tests.Utils;

namespace Sbazuo.Engine.Tests.GameMaps {

	[TestClass]
	public class RectangleMapTest {

		[TestMethod]
		public void CreationTest() {
			RectangleMap map = new RectangleMap("a", 400, 300);
			Assert.AreEqual("a", map.MapId);
			Assert.AreEqual(400, map.GameFieldWidth);
			Assert.AreEqual(300, map.GameFieldHeight);
			Assert.AreEqual(4, map.Areas.Count);
			var points = map.GetPlayerCatapults(new string[] { "w", "x", "y", "z" });
			AssertionUtils.PointsEqual(points["w"], 100, 75);
			AssertionUtils.PointsEqual(points["x"], 100, 225);
			AssertionUtils.PointsEqual(points["y"], 300, 75);
			AssertionUtils.PointsEqual(points["z"], 300, 225);
		}

	}
}
