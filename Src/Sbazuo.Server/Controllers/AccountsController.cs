using Microsoft.AspNetCore.Mvc;
using Sbazuo.Server.Backend;
using Sbazuo.Server.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sbazuo.Server.Controllers {

	[Controller]
	public class AccountsController : Controller {

		private readonly IAccountService AccountService;

		private readonly ISessionService SessionService;

		public AccountsController(IAccountService accountService, ISessionService sessionService) : base() {
			this.AccountService = accountService;
			this.SessionService = sessionService;
		}

		[HttpGet]
		public string Login(AuthRequest authData) {
			if (!AccountService.Login(authData.Nickname, authData.Password)) {
				return null;
			}
			return SessionService.CreateSessionToken(authData.Nickname);
		}

		[HttpGet]
		public string Auth(AuthRequest authData) {
			if (!AccountService.RegisterAccount(authData.Nickname, authData.Password)) {
				return null;
			}
			return SessionService.CreateSessionToken(authData.Nickname);
		}

	}
}
