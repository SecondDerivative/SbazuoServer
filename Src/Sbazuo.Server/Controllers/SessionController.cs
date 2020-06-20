using Microsoft.AspNetCore.Mvc;
using Sbazuo.Server.Backend;
using Sbazuo.Server.Models.Converters.Contracts;
using Sbazuo.Server.Models.Lobbies;
using Sbazuo.Server.Models.Responces;

namespace Sbazuo.Server.Controllers {

	[Controller]
	public class SessionController : Controller {

		private readonly ISessionService SessionService;

		private readonly ILobbyService LobbyService;

		private readonly IConverterContractResolver ModelConverter;

		private readonly IGameService GameService;

		public SessionController(ISessionService sessionProvider, ILobbyService lobbyService, IConverterContractResolver resolver, IGameService gameService = null) : base() {
			this.SessionService = sessionProvider;
			this.LobbyService = lobbyService;
			this.ModelConverter = resolver;
			this.GameService = gameService;
		}

		[HttpGet]
		public AccountInfo[] GetPlayers(string sessionToken) {
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

		[HttpGet]
		public string JoinTemp() {
			string result = SessionService.CreateTempSessionToken();
			GameService.CreateOrJoin(result);
			return result;
		}

		public void Start(string sessionToken) {
			if (!SessionService.ValidateSessionToken(sessionToken)) {
				return;
			}
			LobbyService.StartLobby(SessionService.GetPlayerIdBySessionToken(sessionToken));
		}

	}
}
