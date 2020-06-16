using Microsoft.AspNetCore.Mvc;
using Sbazuo.Server.Backend;
using Sbazuo.Server.Models.Requests;

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
			string accId = AccountService.Login(authData.Nickname, authData.Password);
			return accId == null ? null : SessionService.CreateSessionToken(accId);
		}

		[HttpGet]
		public string Auth(AuthRequest authData) {
			string accId = AccountService.RegisterAccount(authData.Nickname, authData.Password);
			return accId == null ? null : SessionService.CreateSessionToken(accId);
		}

	}
}
