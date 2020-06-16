using Sbazuo.Server.Models.Accounts;
using System.Collections.Generic;

namespace Sbazuo.Server.Backend.Accounts {
	public class MemoryOnlyAccountDataProvider : IAccountDataProvider {

		public Dictionary<string, AccountInfo> Accounts;

		public MemoryOnlyAccountDataProvider() {
			Accounts = new Dictionary<string, AccountInfo>();
#if DEBUG
			Accounts.Add("login", new AccountInfo() { Nickname = "login", PasswordHash = "12345", Id = "ABCD" });
#endif
		}

		public AccountInfo CreateAccount(string nickname, string password) {
			string accId = Utils.StringGenerator.GenerateString();
			AccountInfo result = new AccountInfo { Nickname = nickname, PasswordHash = password, Id = accId };
			Accounts.Add(nickname, result);
			return result;
		}

		public AccountInfo GetAccount(string nickname) {
			return Accounts.ContainsKey(nickname) ? Accounts[nickname] : null;
		}

		public AccountInfo GetAuthInfo(string nickname) {
			return Accounts.ContainsKey(nickname) ? Accounts[nickname] : null;
		}
	}
}
