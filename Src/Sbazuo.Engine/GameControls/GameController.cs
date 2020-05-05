using Sbazuo.Engine.Blocks;
using Sbazuo.Engine.GameRules;
using System;
using System.Collections.Generic;

namespace Sbazuo.Engine.GameControls {

	/// <summary>
	/// represents class, which controlling once game
	/// </summary>
	public class GameController {

		/// <summary>
		/// gets active game rules
		/// </summary>
		public ICollection<IRule> GlobalGameRules { get; private set; }

		/// <summary>
		/// gets players blocks
		/// </summary>
		public ICollection<Block> Blocks { get; private set; }

		/// <summary>
		/// updating game state
		/// </summary>
		public void Update() {

		}

	}
}
