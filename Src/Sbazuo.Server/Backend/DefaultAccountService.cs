using Sbazuo.Server.Backend.Accounts;
using Sbazuo.Server.Backend.Accounts.PasswordComparers;
using Sbazuo.Server.Models.Accounts;

namespace Sbazuo.Server.Backend {
	public class DefaultAccountService : IAccountService {

		private readonly IAccountDataProvider AccountDataProvider;

		private readonly IPasswordComparer PasswordComparer;

		public DefaultAccountService(IAccountDataProvider accountDataProvider, IPasswordComparer passwordComparer) {
			this.AccountDataProvider = accountDataProvider;
			this.PasswordComparer = passwordComparer;
		}

		public string Login(string nickname, string password) {
			var authInfo = AccountDataProvider.GetAccount(nickname);
			if (authInfo == null) {
				return null;
			}
			return PasswordComparer.ValidatePassword(password, authInfo) ? authInfo.Id : null;
		}

		public string RegisterAccount(string nickname, string password) {
			var authInfo = AccountDataProvider.GetAccount(nickname);
			if (authInfo != null) {
				return null;
			}
			AccountInfo info = AccountDataProvider.CreateAccount(nickname, password);
			return info?.Id;
		}
	}
}
