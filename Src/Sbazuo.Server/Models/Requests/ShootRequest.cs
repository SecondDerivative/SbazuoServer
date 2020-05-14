using Sbazuo.Server.Models.Game;
using System.ComponentModel.DataAnnotations;

namespace Sbazuo.Server.Models.Requests {
	public class ShootRequest : SessionRequest {

		[Required]
		public string ProjectileId { get; set; }

		[Required]
		public Point MotionDirection { get; set; }

	}
}
