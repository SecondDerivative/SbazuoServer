using Sbazuo.Engine.Players;
using Sbazuo.Server.Models.Game;
using Sbazuo.Server.Models.Responces.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sbazuo.Server.Models.Converters {
	public class PlayerConverter : Converter {

		public PlayerInfo Convert(Player player) {
			return new PlayerInfo() { CatapultPosition = new Point(player.CatapultPosition), Id = player.Id, OwnAreasIds = player.OwnAreasIds.ToList() };
		}

	}
}
