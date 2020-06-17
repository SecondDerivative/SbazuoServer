using Newtonsoft.Json;
using Sbazuo.Engine.GameControls;
using Sbazuo.Server.Models.Converters;
using Sbazuo.Server.Models.Converters.Attributes;
using Sbazuo.Server.Models.Responces.Game.Blocks;
using Sbazuo.Server.Models.Responces.Game.Projectiles;
using System;
using System.Collections.Generic;

namespace Sbazuo.Server.Models.Responces.Game {

	[AllowConvert(new Type[] { typeof(GameController)})]
	[ModelConverter(typeof(GameControllerConverter))]
	public class GameState {

		[JsonProperty("ConditionId")]
		public string GameStatusId;

		public string CurrentPlayerId;

		public List<BlockInfo> Blocks;

		public List<ProjectileInfo> Projectiles;

		public Dictionary<string, PlayerInfo> Players;

	}
}
