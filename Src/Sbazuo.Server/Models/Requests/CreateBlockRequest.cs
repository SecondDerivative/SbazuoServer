using Newtonsoft.Json;
using Sbazuo.Server.Models.Game;
using System.ComponentModel.DataAnnotations;

namespace Sbazuo.Server.Models.Requests {
	public class CreateBlockRequest : SessionRequest {

		[JsonProperty("Position")]
		[Required]
		public Point BlockPosition;

		[Required]
		public string BlockId;

		[Required]
		public string ShapeId;

	}
}
