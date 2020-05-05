namespace Sbazuo.Engine.GameActions {

	/// <summary>
	/// represents data about gameaction
	/// </summary>
	public abstract class GameAction {

		/// <summary>
		/// gets player, which created this game action
		/// </summary>
		public readonly string InstigatorId;

		/// <summary>
		/// create new instance of <see cref="GameAction"/>
		/// </summary>
		/// <param name="instigatorId"> player's id, which create this game action </param>
		protected GameAction(string instigatorId) {
			InstigatorId = instigatorId;
		}

	}
}
