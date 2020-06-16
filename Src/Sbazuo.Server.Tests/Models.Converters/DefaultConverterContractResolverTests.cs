using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Sbazuo.Engine.Blocks;
using Sbazuo.Engine.GameActions;
using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.GameMaps;
using Sbazuo.Engine.GameMods;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Server.Models.Converters;
using Sbazuo.Server.Models.Converters.Attributes;
using Sbazuo.Server.Models.Converters.Contracts;
using Sbazuo.Server.Models.Lobbies;
using Sbazuo.Server.Models.Responces;
using Sbazuo.Server.Models.Responces.Game;
using Sbazuo.Server.Models.Responces.Game.Projectiles;
using System.Linq;

namespace Sbazuo.Server.Tests.Models.Converters {

	[TestClass]
	public class DefaultConverterContractResolverTests {

		private DefaultConverterContractResolver Resolver;

		private class ModelA {

		}

		private class ModelB : ModelA {

		}

		private class ModelC : ModelA {

		}

		[AllowConvert(typeof(ModelA))]
		[ModelConverter(typeof(Converter1))]
		private class SerX {

		}

		[AllowConvert(typeof(ModelC))]
		[ModelConverter(typeof(Converter2))]
		private class SerY : SerX {

		}

		private class Converter1 : Converter {

			public SerX Convert(ModelA model) {
				Assert.IsTrue(model.GetType() == typeof(ModelA) || model.GetType() == typeof(ModelB));
				return new SerX();
			}

		}

		private class Converter2 : Converter {

			public SerY Convert(ModelC model) {
				Assert.IsTrue(model.GetType() == typeof(ModelC));
				return new SerY();
			}

		}

		[TestInitialize]
		public void Init() {
			Resolver = new DefaultConverterContractResolver();
		}

		[TestMethod]
		public void LobbyTest() {

			Lobby lobby = new Lobby("a", "name", "nick");

			LobbyInfo serializedInfo = Resolver.Convert<Lobby, LobbyInfo>(lobby);
			Assert.AreEqual(lobby.Id, serializedInfo.Id);
			Assert.AreEqual(lobby.LobbyName, serializedInfo.LobbyName);
			Assert.AreEqual(lobby.CreatorId, serializedInfo.CreatorId);
		}

		[TestMethod]
		public void GameStateTest() {
			GameController controller = new GameController(new ThreeStageGameMod(), new RectangleMap("rect", 640, 480), new string[] { "a", "b", "c", "d" });
			controller.ApplyAction(new GameActionShoot("a", "proj", 0, 1));
			controller.Update();
			//controller.ApplyAction(new GameActionCreateBlock("b", "block", "rect", new Geometry.Point2D(0, 0)))
			GameState state = Resolver.Convert<GameController, GameState>(controller);

			System.Console.WriteLine(JsonConvert.SerializeObject(state));

			IProjectile proj = controller.Projectiles.First();
			ProjectileInfo projInfo = state.Projectiles.First();
			Assert.IsNotNull(state);
			Assert.IsNotNull(proj);
			Assert.IsNotNull(projInfo);
			Assert.AreEqual(proj.Health, projInfo.Health);
			Assert.AreEqual(proj.MaxHealth, projInfo.MaxHealth);
			Assert.AreEqual(proj.OwnerId, projInfo.OwnerId);
			Assert.AreEqual(proj.OwnerId, "a");
			Assert.AreEqual(proj.Shape.Radius, projInfo.Radius);
			Assert.AreEqual(proj.MotionVector.X, projInfo.MotionVector.X);

			//PhysicalBlock block
		}

		[TestMethod]
		public void MultiDerivedClassesTest() {

			DefaultConverterContractResolver resolver = new DefaultConverterContractResolver();

			ModelA[] arr = new ModelA[] { new ModelA(), new ModelB(), new ModelC() };
			SerX[] result = Resolver.ConvertCollection<ModelA, SerX>(arr);
			Assert.AreEqual(3, result.Length);
			Assert.AreEqual(result[0].GetType(), typeof(SerX));
			Assert.AreEqual(result[2].GetType(), typeof(SerY));
		}

	}
}
