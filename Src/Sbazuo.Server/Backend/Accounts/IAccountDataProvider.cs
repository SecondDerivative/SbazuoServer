using Sbazuo.Server.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sbazuo.Server.Backend.Accounts {
	public interface IAccountDataProvider {

		AccountInfo GetAccount(string nickname);

		AccountInfo CreateAccount(string nickname, string password);

	}
}
