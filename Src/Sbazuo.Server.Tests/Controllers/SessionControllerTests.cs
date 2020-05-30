using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbazuo.Server.Backend;
using Sbazuo.Server.Backend.Lobbies;
using Sbazuo.Server.Controllers;
using Sbazuo.Server.Models.Converters.Contracts;
using Sbazuo.Server.Models.Responces;

namespace Sbazuo.Server.Tests.Controllers {

	[TestClass]
	public class SessionControllerTests {

		private SessionController Controller;

		private string SessionToken;

		[TestInitialize]
		public void Init() {
			var sessionService = new DefaultSessionService();
			Controller = new SessionController(sessionService, new DefaultLobbyService(new DefaultLobbyFactory()), new DefaultConverterContractResolver());
			SessionToken = sessionService.CreateSessionToken("login");
		}

		[TestCleanup]
		public void Clear() {
			Controller.Dispose();
		}

		[TestMethod]
		public void UnauthTest() {
			Assert.IsNull(Controller.GetLobbies(""));
			Assert.IsNull(Controller.GetPlayers(""));
			Assert.IsNull(Controller.JoinLobby("", "1"));
			Assert.IsNull(Controller.CreateLobby("", "1"));
		}

		[TestMethod]
		public void CreateLobbyTest() {
			LobbyInfo lobby = Controller.CreateLobby(SessionToken, "name");
			Assert.AreEqual("name", lobby.LobbyName);
			Assert.AreEqual("login", lobby.CreatorNickname);
			Assert.AreEqual(1, lobby.PlayerNicks.Count);
			Assert.AreEqual("login", lobby.PlayerNicks[0]);
		}


	}
}
