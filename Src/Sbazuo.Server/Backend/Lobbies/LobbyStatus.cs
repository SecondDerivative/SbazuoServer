using System.Runtime.Serialization;

namespace Sbazuo.Server.Backend.Lobbies {

	public enum LobbyStatus {

		[EnumMember(Value = "Prepare")]
		Preparing,

		[EnumMember(Value = "Play")]
		Playing

	}
}
