using Sbazuo.Engine.Blocks;
using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.GameRules;
using Sbazuo.Engine.Projectiles;
using Sbazuo.Engine.Projectiles.Collisions;
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
			// sort blocks by "is physical block" comparer
			blocks.Sort((a, b) => {
				bool aPhys = a is PhysicalBlock;
				bool bPhys = b is PhysicalBlock;
				return -aPhys.CompareTo(bPhys);
			});
			// begin checks collision and correct motion vector
			foreach (Block b in blocks) {
				IProjectileCollision collision = b.HasCollision(controller.ShapeProvider, Projectile);
				if (collision == null) {
					continue;
				}
				// update motion vector
				ResultMotionVector = collision.CreateReflectionVector();
				if (collision.BreakingRuleApply) {
					return;
				}
			}
			foreach (IRule rule in controller.GlobalGameRules) {
				rule.ApplyToGameAction(this, controller);
			}
			foreach (Block b in blocks) {
				b.ApplyToGameAction(this, controller);
			}
			Projectile.ApplyToGameAction(this, controller);
		}

		public override void ApplyToGame(GameController controller) {
			Projectile.MotionVector = ResultMotionVector;
			Projectile.Shape.Center += ResultMotionVector;
		}
	}
}
