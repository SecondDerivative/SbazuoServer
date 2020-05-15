using Sbazuo.Server.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sbazuo.Server.Backend.Accounts {
	public interface IAccountDataProvider {

		AccountSecureInfo GetAuthInfo(string nickname);

		AccountPublicInfo GetAccount(string nickname);

		void CreateAccount(string nickname, string password);

	}
}
