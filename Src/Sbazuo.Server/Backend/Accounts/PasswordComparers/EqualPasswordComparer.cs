namespace Sbazuo.Server.Backend.Accounts.PasswordComparers {

	public class EqualPasswordComparer : IPasswordComparer {

		public bool ValidatePassword(string inputPassword, string validPassword) {
			return inputPassword == validPassword;
		}
	}
}
