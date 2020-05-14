using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sbazuo.Server.Models.Requests {
	public class AuthRequest {

		[Required]
		public string Nickname { get; set; }

		[DataType(DataType.Password)]
		[Required]
		public string Password { get; set; }

	}
}
