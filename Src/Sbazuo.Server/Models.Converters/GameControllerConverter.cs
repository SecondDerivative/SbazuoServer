using Sbazuo.Engine.Blocks;
using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.GameMods;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Server.Models.Responces.Game;
using Sbazuo.Server.Models.Responces.Game.Blocks;
using Sbazuo.Server.Models.Responces.Game.Projectiles;
using System.Collections.Generic;
using System.Linq;

namespace Sbazuo.Server.Models.Converters {
	public class GameControllerConverter : Converter {

		public GameState Convert(GameController game) {
			ICollection<BlockInfo> blocks = new List<BlockInfo>();
			foreach (Block block in game.Blocks) {
				blocks.Add(Invoker.Convert<Block, BlockInfo>(block));
			}
			ICollection<ProjectileInfo> projectiles = new List<ProjectileInfo>();
			foreach (IProjectile projectile in game.Projectiles) {
				projectiles.Add(Invoker.Convert<IProjectile, ProjectileInfo>(projectile));
			}
			ThreeStageGameMod mod = (game.GameMod as ThreeStageGameMod);
			string gameStatusId = mod?.GameStage.ToString();
			return new GameState() { Blocks = blocks.ToList(), Projectiles = projectiles.ToList(), CurrentPlayerId = mod?.CurrentPlayerId, GameStatusId = gameStatusId };
		}

	}
}
