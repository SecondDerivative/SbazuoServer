using Sbazuo.Engine.GameActions;
using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.GameMaps;
using Sbazuo.Engine.GameMods;
using Sbazuo.Geometry;
using Sbazuo.Server.Models.Game;
using Sbazuo.Server.Utils;
using System.Collections.Generic;
using System.Threading;

namespace Sbazuo.Server.Backend {
	public class DefaultGameService : IGameService {


		private readonly IDictionary<string, GameController> Games;

		private readonly IDictionary<string, string> PlayerIdToGameId;

		private readonly int TickRate = 15; // ~66 updates per second

		private object Sync = new object();

		public DefaultGameService() {
			Games = new Dictionary<string, GameController>();
			PlayerIdToGameId = new Dictionary<string, string>();
			Thread thread = new Thread(GameLoop);
			thread.Start();
		}


		public void GameCreateBlock(string playerId, string blockId, string shapeId, Point point) {
			lock (Sync) {
				GameController game = GetGameByPlayerId(playerId);
				game?.ApplyAction(new GameActionCreateBlock(playerId, blockId, shapeId, point.ToPoint2D()));
			}
		}

		public void GameShoot(string playerId, string projectileId, Point direction) {
			lock (Sync) {
				GameController game = GetGameByPlayerId(playerId);
				Vector2D directionVector = direction.ToVector2D();
				if (directionVector.Length > 1) {
					directionVector = directionVector.Normalized;
				}
				game?.ApplyAction(new GameActionShoot(playerId, projectileId, directionVector.GetPolarAngle(), directionVector.Length));
			}
		}

		public string RegisterGame(string mapId, string modId, IEnumerable<string> playerIds) {
			string gameId = StringGenerator.GenerateString();
			lock (Sync) {
				foreach (string playerId in playerIds) {
					if (PlayerIdToGameId.ContainsKey(playerId)) {
						return null;
					}
				}
				GameControllerBuilder builder = new GameControllerBuilder();
				foreach (string playerId in playerIds) {
					PlayerIdToGameId.Add(gameId, playerId);
				}
				// TODO gamemod factory, game map factory
				Games.Add(gameId, builder.CreateGame(new ThreeStageGameMod(), new RectangleMap("rect", 640, 480), playerIds));
			}
			return gameId;
		}

		private GameController GetGameByPlayerId(string playerId) {
			lock (Sync) {
				if (!PlayerIdToGameId.ContainsKey(playerId)) {
					return null;
				}
				return Games[PlayerIdToGameId[playerId]];
			}
		}

		private void GameLoop() {
			while (true) {
				lock (Sync) {
					foreach (GameController game in Games.Values) {
						game.Update();
					}
				}
				Thread.Sleep(TickRate);
			}
		}

		public void CreateOrJoin(string playerId) {
			lock (Sync) {
				if (Games.Count == 0) {
					RegisterGame(null, null, new string[] { "1111", "1112", "1113", "1114" });
				}
			}
		}
	}
}
