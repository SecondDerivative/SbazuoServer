using Sbazuo.Engine.GameActions;
using Sbazuo.Engine.GameControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sbazuo.Engine.Triggers {

	/// <summary>
	/// interface for game actions triggers
	/// </summary>
	public interface ITrigger {

		/// <summary>
		/// checking applied game action
		/// </summary>
		/// <param name="controller"> current game </param>
		/// <param name="action"> applied game action </param>
		void Consume(GameAction action, GameController controller);

	}
}
