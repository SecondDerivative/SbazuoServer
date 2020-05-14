using Sbazuo.Server.Backend.Accounts;
using Sbazuo.Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public string GetPlayerNicknameBySessionToken(string sessionToken) {
			if (!ValidateSessionToken(sessionToken)) {
				return null;
			}
			return OnlinePlayers.Where(x => x.Value == sessionToken).FirstOrDefault().Key;
		}

	}
}
