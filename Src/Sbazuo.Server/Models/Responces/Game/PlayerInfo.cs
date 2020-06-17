using Sbazuo.Engine.Players;
using Sbazuo.Server.Models.Converters;
using Sbazuo.Server.Models.Converters.Attributes;
using Sbazuo.Server.Models.Game;
using System.Collections.Generic;

namespace Sbazuo.Server.Models.Responces.Game {

	[AllowConvert(typeof(Player))]
	[ModelConverter(typeof(PlayerConverter))]
	public class PlayerInfo {

		public Point CatapultPosition { get; set; }

		public string Id { get; set; }

		public List<string> OwnAreasIds { get; set; }

	}
}
