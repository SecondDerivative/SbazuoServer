using Sbazuo.Engine.GameActions;
using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.GameMods.ThreeStageGame;
using Sbazuo.Engine.Triggers;
using System.Collections.Generic;
using System.Linq;

namespace Sbazuo.Engine.GameMods {
	public class ThreeStageGameMod : RealTimeGameMod, ITrigger {

		public override IEnumerable<ITrigger> PrimaryTriggers => new ITrigger[] { this };

		public GameStage GameStage { get; private set; }

		public string CurrentPlayerId { get; private set; }

		private int CurrentPlayerIndex = 0;

		public ThreeStageGameMod() : base() {

		}

		public override bool ValidateGameAction(GameController controller, GameAction action) {
			if (string.IsNullOrEmpty(action.InstigatorId)) {
				return true;
			}
			return action.InstigatorId == CurrentPlayerId;
		}

		public virtual void Consume(GameAction action, GameController controller) {
			if (action is GameActionRemoveProjectile && action.InstigatorId == CurrentPlayerId) {
				controller.ApplyAction(new GameActionNextTurn());
			}
			if (action is GameActionNextTurn) {
				string[] players = controller.Players.Select(x => x.Id).ToArray();
				CurrentPlayerId = players[(++CurrentPlayerIndex) % players.Length];
			}
		}

		public override void Init(GameController controller) {
			CurrentPlayerId = controller.Players.First().Id;
		}
	}
}
