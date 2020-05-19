using Sbazuo.Server.Backend.Accounts;
using Sbazuo.Server.Backend.Accounts.PasswordComparers;

namespace Sbazuo.Server.Backend {
	public class DefaultAccountService : IAccountService {

		private readonly IAccountDataProvider AccountDataProvider;

		private readonly IPasswordComparer PasswordComparer;

		public DefaultAccountService(IAccountDataProvider accountDataProvider, IPasswordComparer passwordComparer) {
			this.AccountDataProvider = accountDataProvider;
			this.PasswordComparer = passwordComparer;
		}

		public bool Login(string nickname, string password) {
			var authInfo = AccountDataProvider.GetAuthInfo(nickname);
			if (authInfo == null) {
				return false;
			}
			return PasswordComparer.ValidatePassword(password, authInfo.PasswordHash);
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
