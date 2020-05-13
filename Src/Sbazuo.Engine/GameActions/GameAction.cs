using Sbazuo.Engine.GameControls;

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

		/// <summary>
		/// apply game rules to this game action
		/// </summary>
		/// <param name="controller"></param>
		public virtual void ApplyRules(GameController controller) {
			foreach (var rule in controller.GlobalGameRules) {
				rule.ApplyToGameAction(this, controller);
			}
			foreach (var blockRule in controller.Blocks) {
				blockRule.ApplyToGameAction(this, controller);
			}
			foreach (var projectile in controller.Projectiles) {
				projectile.ApplyToGameAction(this, controller);
			}
		}

		/// <summary>
		/// apply triggers to this game action
		/// </summary>
		/// <param name="controller"></param>
		public virtual void ApplyTriggers(GameController controller) {
			foreach (var trigger in controller.Triggers) {
				trigger.Consume(this, controller);
			}
			foreach (var block in controller.Blocks) {
				block.Consume(this, controller);
			}
			foreach (var projectile in controller.Projectiles) {
				projectile.Consume(this, controller);
			}
		}

		/// <summary>
		/// apply game action to current game
		/// </summary>
		public abstract void ApplyToGame(GameController controller);

	}
}
