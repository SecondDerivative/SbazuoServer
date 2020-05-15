using Sbazuo.Server.Models.Accounts;
using System.Collections.Generic;

namespace Sbazuo.Server.Backend.Accounts {
	public class MemoryOnlyAccountDataProvider : IAccountDataProvider {

		public Dictionary<string, AccountPublicInfo> PublicInfos;

		public Dictionary<string, AccountSecureInfo> SecureInfos;

		public MemoryOnlyAccountDataProvider() {
			PublicInfos = new Dictionary<string, AccountPublicInfo>();
			SecureInfos = new Dictionary<string, AccountSecureInfo>();
		}

		public void CreateAccount(string nickname, string password) {
			PublicInfos.Add(nickname, new AccountPublicInfo { Nickname = nickname });
			SecureInfos.Add(nickname, new AccountSecureInfo { Nickname = nickname, PasswordHash = password });
		}

		public AccountPublicInfo GetAccount(string nickname) {
			return PublicInfos.ContainsKey(nickname) ? PublicInfos[nickname] : null;
		}

		public AccountSecureInfo GetAuthInfo(string nickname) {
			return SecureInfos.ContainsKey(nickname) ? SecureInfos[nickname] : null;
		}
	}
}
