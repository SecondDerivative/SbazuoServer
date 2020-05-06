using Sbazuo.Engine.GameActions;
using Sbazuo.Engine.GameControls;
using Sbazuo.Geometry;

namespace Sbazuo.Engine.Projectiles {

	/// <summary>
	/// represents information about default instance of <see cref="IProjectile"/>
	/// </summary>
	public class DefaultProjectile : IProjectile {

		public Vector2D MotionVector { get; set; }

		public Circle2D Shape { get; }

		public string OwnerId { get; }

		public int Health { get; set; }

		public int MaxHealth { get; }

		/// <summary>
		/// create new instance of <see cref="DefaultProjectile"/>
		/// </summary>
		public DefaultProjectile(Circle2D shape, Vector2D primaryMotionVector, string ownerId, int primaryHealth) {
			this.Shape = shape;
			this.MotionVector = primaryMotionVector;
			this.OwnerId = ownerId;
			this.MaxHealth = primaryHealth;
			this.Health = primaryHealth;
		}

		public void ApplyToGameAction(GameAction action, GameController controller) {

		}
	}
}
