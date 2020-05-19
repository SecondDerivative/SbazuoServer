﻿namespace Sbazuo.Server.Backend.Accounts.PasswordComparers {

	/// <summary>
	/// interface for password validator
	/// </summary>
	public interface IPasswordComparer {

		bool ValidatePassword(string inputPassword, string validPassword);

	}
}
