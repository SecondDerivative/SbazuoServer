namespace Sbazuo.Engine.GameActions {
	
	/// <summary>
	/// represents class, which applying gameactions
	/// </summary>
	public interface IGameActionProvider {

		/// <summary>
		/// apply <see cref="GameAction"/> to game state
		/// </summary>
		void ApplyGameAction(GameAction action);

	}
}
