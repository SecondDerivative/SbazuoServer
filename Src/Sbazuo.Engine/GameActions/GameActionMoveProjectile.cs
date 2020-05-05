using Sbazuo.Engine.Blocks;
using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Geometry;
using System.Collections.Generic;
using System.Linq;

namespace Sbazuo.Engine.GameActions {
	public class GameActionMoveProjectile : GameAction {

		/// <summary>
		/// gets movable projectile
		/// </summary>
		public readonly IProjectile Projectile;

		/// <summary>
		/// gets or sets result projectile motion vector
		/// </summary>
		public Vector2D ResultMotionVector { get; set; }

		public GameActionMoveProjectile(IProjectile projectile) : base(projectile.OwnerId) {
			this.Projectile = projectile;
			ResultMotionVector = projectile.MotionVector;
		}

		public override void ApplyRules(GameController controller) {
			List<Block> blocks = controller.Blocks.ToList();
			blocks.Sort((a, b) => {
				bool aPhys = a is PhysicalBlock;
				bool bPhys = b is PhysicalBlock;
				return -aPhys.CompareTo(bPhys);
			});
			foreach (Block b in blocks) {
				IProjectileCollision collision = b.HasCollision(Projectile);
				if (collision == null) {
					continue;
				}
				ResultMotionVector = collision.CreateReflectionVector();
				if (collision.BreakingRuleApply) {
					return;
				}
			}
			foreach (Block b in blocks) {
				b.ApplyToGameAction(this, controller);
			}
		}

		public override void ApplyToGame(GameController controller) {
			Projectile.MotionVector = ResultMotionVector;
			Projectile.Shape.Center += ResultMotionVector;
		}
	}
}
