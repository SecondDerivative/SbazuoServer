using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbazuo.Server.Backend;
using Sbazuo.Server.Backend.Accounts;
using Sbazuo.Server.Backend.Accounts.PasswordComparers;
using Sbazuo.Server.Controllers;

namespace Sbazuo.Server.Tests.Controllers {

	[TestClass]
	public class AccountsControllerTests {

		private AccountsController Controller;

		[TestInitialize]
		public void Init() {
			Controller = new AccountsController(new DefaultAccountService(new MemoryOnlyAccountDataProvider(), new EqualPasswordComparer()), new DefaultSessionService());
		}

		[TestCleanup]
		public void Clear() {
			Controller.Dispose();
		}

		[TestMethod]
		public void LoginTest() {
			string token = Controller.Login(new Server.Models.Requests.AuthRequest() { Nickname = "login", Password = "12345" });
			Assert.IsFalse(string.IsNullOrEmpty(token));
		}

	}
}
