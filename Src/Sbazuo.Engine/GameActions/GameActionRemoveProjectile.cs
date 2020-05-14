﻿using Sbazuo.Engine.GameControls;
using Sbazuo.Engine.Projectiles;
using System;

namespace Sbazuo.Engine.GameActions {
	public class GameActionRemoveProjectile : GameAction {

		public readonly IProjectile Projectile;

		public GameActionRemoveProjectile(IProjectile projectile) : base(projectile.OwnerId) {
			this.Projectile = projectile;
		}

		public override void ApplyToGame(GameController controller) {
			controller.Projectiles.Remove(Projectile);
		}

	}
}
