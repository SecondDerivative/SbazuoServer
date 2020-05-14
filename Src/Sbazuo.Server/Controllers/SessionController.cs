using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sbazuo.Server.Models.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sbazuo.Server.Controllers {

	[Controller]
	public class SessionController : Controller {

		public async Task<JoinResponce> Join() {
			return new JoinResponce() { PlayerId = "123", Token = "abcd" };
		}

	}
}
