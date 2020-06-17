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
			Service.CreateLobby("userid", "lobby name");
			ILobby lobby = Service.GetLobbyByPlayerId("userid");
			Assert.IsNotNull(lobby);
		}

		[TestMethod]
		public void JoinLobbyTest() {
			Service.CreateLobby("userid", "lobby name");
			ILobby lobby = Service.GetLobbyByPlayerId("userid");
			Service.Join("user2", lobby.Id);
			ILobby joinedLobby = Service.GetLobbyByPlayerId("user2");
			Assert.AreSame(lobby, joinedLobby);
		}

		[TestMethod]
		public void LeaveLobbyTest() {
			Service.CreateLobby("user", "lobby name");
			Assert.AreEqual(1, Service.LobbiesCount);
			Service.LeaveLobby("user");
			Assert.AreEqual(0, Service.LobbiesCount);

			Service.CreateLobby("user", "lobby name");
			ILobby lobby = Service.GetLobbyByPlayerId("user");
			Service.Join("user2", lobby.Id);
			Service.LeaveLobby("user");
			Service.LeaveLobby("user2");
			Assert.AreEqual(0, Service.LobbiesCount);
		}

		[TestMethod]
		public void RejoinLobbyTest() {
			ILobby lobby1 = Service.CreateLobby("user", "lobby 1");
			Assert.IsNotNull(lobby1);
			ILobby lobby2 = Service.CreateLobby("user", "lobby 2");
			Assert.IsNull(lobby2);
			string joinedLobbyId = Service.Join("user2", lobby1.Id);
			Assert.AreEqual(2, lobby1.PlayersCount);
			Assert.AreEqual(joinedLobbyId, lobby1.Id);

			joinedLobbyId = Service.Join("user2", "abc");
			Assert.AreEqual(1, lobby1.PlayersCount);
			//Assert.AreEqual(joinedLobbyId, lobby2.Id);

			lobby2 = Service.CreateLobby("user2", "lobby2");
			Assert.IsNotNull(lobby2);
		}

	}
}
