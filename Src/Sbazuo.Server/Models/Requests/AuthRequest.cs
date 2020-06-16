using System.ComponentModel.DataAnnotations;

namespace Sbazuo.Server.Models.Requests {
	public class AuthRequest {

		[Required]
		public string Nickname { get; set; }

		[DataType(DataType.Password)]
		[Required]
		public string Password { get; set; }

	}
}
