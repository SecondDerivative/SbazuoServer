using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbazuo.Server.Backend;
using Sbazuo.Server.Backend.Accounts;
using Sbazuo.Server.Backend.Accounts.PasswordComparers;

namespace Sbazuo.Server.Tests.Backend {

	[TestClass]
	public class DefaultAccountServiceTests {

		private DefaultAccountService Service;

		[TestInitialize]
		public void Init() {
			Service = new DefaultAccountService(new MemoryOnlyAccountDataProvider(), new EqualPasswordComparer());
		}

		[TestCleanup]
		public void Clear() {
			Service = null;
		}

		[TestMethod]
		public void LoginTest() {
			Assert.IsTrue(Service.Login("login", "12345"));
			Assert.IsFalse(Service.Login("login", ""));
			Assert.IsFalse(Service.Login("login", "123432"));
			Assert.IsFalse(Service.Login("", "12345"));
		}

		[TestMethod]
		public void RegisterAccountTest() {
			Assert.IsTrue(Service.RegisterAccount("usr", "4321"));
			Assert.IsTrue(Service.Login("usr", "4321"));
		}

	}
}
