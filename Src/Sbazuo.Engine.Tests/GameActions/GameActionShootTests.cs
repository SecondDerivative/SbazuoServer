using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbazuo.Engine.GameActions;
using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sbazuo.Engine.Tests.GameActions {

	[TestClass]
	public class GameActionShootTests {

		[TestMethod]
		public void CreationTest() {
			GameActionShoot action = new GameActionShoot("inst", "proj", 0.548, 0.22);
			Assert.AreEqual("inst", action.InstigatorId);
			Assert.AreEqual("proj", action.ProjectileId);
			Assert.AreEqual(0.548, action.MotionAngle);
			Assert.AreEqual(0.22, action.VelocityMult);
		}

		[TestMethod]
		public void ApplyTest() {
			GameController controller = CreationUtils.CreateDefaultGame();
			int prevProjectiles = controller.Projectiles.Count;
			GameActionShoot action = new GameActionShoot(controller.Players.First().Id, CreationUtils.DefaultProjectileId, 0, 1);
			controller.ApplyAction(action);
			Assert.AreEqual(prevProjectiles + 1, controller.Projectiles.Count);
		}
	}
}
