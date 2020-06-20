using Sbazuo.Server.Models.Accounts;
using Sbazuo.Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sbazuo.Server.Backend {
	public class DefaultSessionService : ISessionService {

		/// <summary>
		/// dictionary of online players
		/// key - player's nick name
		/// value - session id
		/// </summary>
		private IDictionary<string, string> OnlinePlayers;

		public DefaultSessionService() {
			OnlinePlayers = new Dictionary<string, string>();
		}

		public bool ValidateSessionToken(string sessionToken) {
			return OnlinePlayers.Values.Contains(sessionToken);
		}

		public string CreateSessionToken(string playerNickname) {
			string token = StringGenerator.GenerateString();
			if (OnlinePlayers.ContainsKey(playerNickname)) {
				OnlinePlayers.Remove(playerNickname);
			}
			OnlinePlayers.Add(playerNickname, token);
			return token;
		}

		public string GetPlayerIdBySessionToken(string sessionToken) {
			if (!ValidateSessionToken(sessionToken)) {
				return null;
			}
			return OnlinePlayers.Where(x => x.Value == sessionToken).FirstOrDefault().Key;
		}

		public IEnumerable<AccountInfo> GetPlayers() {
			throw new NotImplementedException();
		}

		public string CreateTempSessionToken() {
			string token = "1111";
			while (OnlinePlayers.ContainsKey(token)) {
				token = (int.Parse(token) + 1).ToString();
			}
			OnlinePlayers.Add(token, token);
			return token;
		}
	}
}
