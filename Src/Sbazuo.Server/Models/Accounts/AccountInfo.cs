using Newtonsoft.Json;

namespace Sbazuo.Server.Models.Accounts {

	public class AccountInfo {

		public string Nickname { get; set; }

		public string Id { get; set; }

		[JsonIgnore]
		public string PasswordHash { get; set; }

		[JsonIgnore]
		public string PasswordSalt { get; set; }

	}
}
