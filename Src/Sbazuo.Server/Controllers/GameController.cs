using Microsoft.AspNetCore.Mvc;
using Sbazuo.Server.Backend;
using Sbazuo.Server.Models.Requests;

namespace Sbazuo.Server.Controllers {

	[Controller]
	public class GameController : Controller {

		private readonly ISessionService SessionService;

		private readonly IGameService GameService;

		public GameController(ISessionService sessionService, IGameService gameService) {
			this.SessionService = sessionService;
			this.GameService = gameService;
		}

		public void CreateBlock(CreateBlockRequest request) {
			if (!SessionService.ValidateSessionToken(request.SessionToken)) {
				return;
			}
			string playerId = SessionService.GetPlayerIdBySessionToken(request.SessionToken);
			GameService.GameCreateBlock(playerId, request.BlockId, request.ShapeId, request.BlockPosition);
		}

		public void Shoot(ShootRequest request) {
			if (!SessionService.ValidateSessionToken(request.SessionToken)) {
				return;
			}
			string playerId = SessionService.GetPlayerIdBySessionToken(request.SessionToken);
			GameService.GameShoot(playerId, request.ProjectileId, request.MotionDirection);
		}

	}
}
