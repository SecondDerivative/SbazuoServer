using Sbazuo.Server.Backend.Accounts;

namespace Sbazuo.Server.Backend {
	public class DefaultAccountService : IAccountService {

		private readonly IAccountDataProvider AccountDataProvider;

		public DefaultAccountService(IAccountDataProvider accountDataProvider) {
			this.AccountDataProvider = accountDataProvider;
		}

		public bool Login(string nickname, string password) {
			var authInfo = AccountDataProvider.GetAuthInfo(nickname);
			if (authInfo == null) {
				return false;
			}
			return authInfo.PasswordHash == password;
		}

		public bool RegisterAccount(string nickname, string password) {
			var authInfo = AccountDataProvider.GetAuthInfo(nickname);
			if (authInfo != null) {
				return false;
			}
			AccountDataProvider.CreateAccount(nickname, password);
			return true;
		}
	}
}
