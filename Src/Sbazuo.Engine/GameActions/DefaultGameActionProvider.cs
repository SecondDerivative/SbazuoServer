using Sbazuo.Engine.GameControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sbazuo.Engine.GameActions {
	public class DefaultGameActionProvider : IGameActionProvider {

		private readonly GameController GameController;

		public DefaultGameActionProvider(GameController controller) {
			this.GameController = controller;
		}

		public void ApplyGameAction(GameAction action) {
			action.ApplyRules(GameController);
			action.ApplyToGame(GameController);
		}
	}
}
