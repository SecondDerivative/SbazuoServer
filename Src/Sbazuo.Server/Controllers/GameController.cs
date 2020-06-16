using Microsoft.AspNetCore.Mvc;
using Sbazuo.Server.Backend;
using Sbazuo.Server.Models.Requests;
using System;

namespace Sbazuo.Server.Controllers {

	[Controller]
	public class GameController : Controller {

		private readonly ISessionService SessionService;

		public GameController(ISessionService sessionService) {
			this.SessionService = sessionService;
		}

		public void CreateBlock(CreateBlockRequest request) {
			Console.WriteLine("create block");
		}

		public void Shoot(ShootRequest request) {
			if (SessionService.ValidateSessionToken(request.SessionToken)) {
				return;
			}
			
		}

	}
}
