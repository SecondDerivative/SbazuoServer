using System.Runtime.Serialization;

namespace Sbazuo.Server.Models.Lobbies {

	public enum LobbyStatus {

		[EnumMember(Value = "Prepare")]
		Preparing,

		[EnumMember(Value = "Play")]
		Playing

	}
}
