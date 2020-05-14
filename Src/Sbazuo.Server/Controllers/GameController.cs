using Microsoft.AspNetCore.Mvc;
using Sbazuo.Server.Models.Requests;
using System;

namespace Sbazuo.Server.Controllers {

	[Controller]
	public class GameController : Controller {

		public void CreateBlock(CreateBlockRequest request) {
			Console.WriteLine("create block");
		}

		public string Shoot(ShootRequest request) {
			//Console.WriteLine("shoot");
			/*if (request != null) {
				return "shoot2 " + request.SessionToken;
			} else {
				return "shoot0";
			}*/
			return "shoot " + request?.SessionToken + " " + request?.ProjectileId;
		}

	}
}
