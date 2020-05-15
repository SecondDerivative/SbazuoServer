namespace Sbazuo.Server.Models.Accounts {

	public class AccountSecureInfo {

		public string Nickname { get; set; }

		public string PasswordHash { get; set; }

		public string PasswordSalt { get; set; }

	}
}
