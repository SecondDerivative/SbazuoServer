using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbazuo.Server.Backend;
using Sbazuo.Server.Backend.Lobbies;
using Sbazuo.Server.Models.Lobbies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sbazuo.Server.Tests.Backend {

	[TestClass]
	public class DefaultLobbyServiceTests {

		private DefaultLobbyService Service;

		[TestInitialize]
		public void Init() {
			Service = new DefaultLobbyService(new DefaultLobbyFactory());
		}

		[TestCleanup]
		public void Clear() {
			Service = null;
		}

		[TestMethod]
		public void CreateLobbyTest() {
			Service.CreateLobby("user", "lobby name");
			ILobby lobby = Service.GetLobbyByPlayerNickname("user");
			Assert.IsNotNull(lobby);
		}

		[TestMethod]
		public void JoinLobbyTest() {
			Service.CreateLobby("user", "lobby name");
			ILobby lobby = Service.GetLobbyByPlayerNickname("user");
			Service.Join("user2", lobby.Id);
		}

		[TestMethod]
		public void LeaveLobbyTest() {
			Service.CreateLobby("user", "lobby name");
			Assert.AreEqual(1, Service.LobbiesCount);
			Service.LeaveLobby("user");
			Assert.AreEqual(0, Service.LobbiesCount);

			Service.CreateLobby("user", "lobby name");
			ILobby lobby = Service.GetLobbyByPlayerNickname("user");
			Service.Join("user2", lobby.Id);
			Service.LeaveLobby("user");
			Service.LeaveLobby("user2");
			Assert.AreEqual(0, Service.LobbiesCount);
		}

	}
}
