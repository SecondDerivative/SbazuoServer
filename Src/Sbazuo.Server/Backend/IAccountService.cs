using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sbazuo.Server.Backend {
	public interface IAccountService {

		bool RegisterAccount(string nickname, string password);

		bool Login(string nickname, string password);

	}
}
