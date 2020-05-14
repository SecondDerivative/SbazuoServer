using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Sbazuo.Server.Models.Requests {
	public abstract class SessionRequest {

		[JsonProperty("Token")]
		[Required]
		public string SessionToken { get; set; }

	}
}
