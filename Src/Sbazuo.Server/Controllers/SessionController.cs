using Microsoft.AspNetCore.Mvc;
using Sbazuo.Server.Backend;
using Sbazuo.Server.Models.Accounts;
using Sbazuo.Server.Models.Converters.Contracts;
using Sbazuo.Server.Models.Lobbies;
using Sbazuo.Server.Models.Responces;

namespace Sbazuo.Server.Controllers {

	[Controller]
	public class SessionController : Controller {

		private readonly ISessionService SessionService;

		private readonly ILobbyService LobbyService;

		private readonly IConverterContractResolver ModelConverter;

		public SessionController(ISessionService sessionProvider, ILobbyService lobbyService, IConverterContractResolver resolver) : base() {
			this.SessionService = sessionProvider;
			this.LobbyService = lobbyService;
			this.ModelConverter = resolver;
		}

		[HttpGet]
		public Models.Responces.AccountInfo[] GetPlayers(string sessionToken) {
			if (!SessionService.ValidateSessionToken(sessionToken)) {
				return null;
			}
			return ModelConverter.ConvertCollection<Models.Accounts.AccountInfo, Models.Responces.AccountInfo>(SessionService.GetPlayers());
		}

		[HttpGet]
		public LobbyInfo[] GetLobbies(string sessionToken) {
			if (!SessionService.ValidateSessionToken(sessionToken)) {
				return null;
			}
			return ModelConverter.ConvertCollection<ILobby, LobbyInfo>(LobbyService.CreatedLobbies);
		}

		[HttpGet]
		public LobbyInfo CreateLobby(string sessionToken, string lobbyName) {
			if (!SessionService.ValidateSessionToken(sessionToken)) {
				return null;
			}
			return ModelConverter.Convert<ILobby, LobbyInfo>(LobbyService.CreateLobby(SessionService.GetPlayerIdBySessionToken(sessionToken), lobbyName));
		}

		[HttpGet]
		public JoinResponce JoinLobby(string sessionToken, string lobbyId) {
			if (!SessionService.ValidateSessionToken(sessionToken)) {
				return null;
			}
			return new JoinResponce() { PlayerId = LobbyService.Join(sessionToken, lobbyId), Token = sessionToken };
		}

		[HttpGet]
		public void LeaveLobby(string sessionToken) {
			if (!SessionService.ValidateSessionToken(sessionToken)) {
				return;
			}
			LobbyService.LeaveLobby(SessionService.GetPlayerIdBySessionToken(sessionToken));
		}

	}
}
