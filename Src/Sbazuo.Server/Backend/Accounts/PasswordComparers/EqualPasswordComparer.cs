using Sbazuo.Server.Models.Accounts;

namespace Sbazuo.Server.Backend.Accounts.PasswordComparers {

	public class EqualPasswordComparer : IPasswordComparer {

		public bool ValidatePassword(string inputPassword, AccountSecureInfo account) {
			return inputPassword == account.PasswordHash;
		}
	}
}
