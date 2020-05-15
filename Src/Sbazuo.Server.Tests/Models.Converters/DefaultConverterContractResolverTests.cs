using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbazuo.Server.Models.Converters;
using Sbazuo.Server.Models.Converters.Attributes;
using Sbazuo.Server.Models.Converters.Contracts;
using Sbazuo.Server.Models.Lobbies;
using Sbazuo.Server.Models.Responces;

namespace Sbazuo.Server.Tests.Models.Converters {

	[TestClass]
	public class DefaultConverterContractResolverTests {

		private class ModelA {

		}

		private class ModelB : ModelA {

		}

		private class ModelC : ModelA {

		}

		[AllowConvert(typeof(ModelA), typeof(ModelB))]
		[ModelConverter(typeof(Converter1))]
		private class SerX {

		}

		[AllowConvert(typeof(ModelC))]
		[ModelConverter(typeof(Converter2))]
		private class SerY : SerX {

		}

		private class Converter1 : IConverter {

			public object Convert(object model) {
				Assert.IsTrue(model.GetType() == typeof(ModelA) || model.GetType() == typeof(ModelB));
				return new SerX();
			}

		}

		private class Converter2 : IConverter {

			public object Convert(object model) {
				Assert.IsTrue(model.GetType() == typeof(ModelC));
				return new SerY();
			}

		}

		[TestMethod]
		public void LobbyTest() {

			DefaultConverterContractResolver resolver = new DefaultConverterContractResolver();
			Lobby lobby = new Lobby("a", "name", "nick");

			LobbyInfo serializedInfo = resolver.Convert<Lobby, LobbyInfo>(lobby);
			Assert.AreEqual(lobby.Id, serializedInfo.Id);
			Assert.AreEqual(lobby.LobbyName, serializedInfo.LobbyName);
			Assert.AreEqual(lobby.CreatorNick, serializedInfo.CreatorNickname);
		}

		[TestMethod]
		public void MultiDerivedClassesTest() {

			DefaultConverterContractResolver resolver = new DefaultConverterContractResolver();

			ModelA[] arr = new ModelA[] { new ModelA(), new ModelB(), new ModelC() };
			SerX[] result = resolver.ConvertCollection<ModelA, SerX>(arr);
			Assert.AreEqual(3, result.Length);
			Assert.AreEqual(result[0].GetType(), typeof(SerX));
			Assert.AreEqual(result[1].GetType(), typeof(SerX));
			Assert.AreEqual(result[2].GetType(), typeof(SerY));
		}

	}
}
