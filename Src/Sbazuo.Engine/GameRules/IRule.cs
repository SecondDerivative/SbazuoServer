using Sbazuo.Engine.GameActions;
using Sbazuo.Engine.GameControls;

namespace Sbazuo.Engine.GameRules {

	/// <summary>
	/// represents class, which can observe and change gameactions
	/// </summary>
	public interface IRule {

		/// <summary>
		/// observing applicable game action and change it if needed
		/// </summary>
		void Observe(GameAction action, GameController controller);

	}
}
