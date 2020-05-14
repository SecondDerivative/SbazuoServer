using Sbazuo.Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbazuo.Server.Backend {
	public class DefaultSessionProvider : ISessionProvider {

		private ICollection<string> Tokens;

		private static Random Rand = new Random();

		public DefaultSessionProvider() {
			Tokens = new HashSet<string>();
		}

		public string CreateSessionToken() {
			string token = StringGenerator.GenerateString();
			Tokens.Add(token);
			return token;
		}

		public bool ValidateSessionToken(string sessionToken) {
			return Tokens.Contains(sessionToken);
		}

	}
}
