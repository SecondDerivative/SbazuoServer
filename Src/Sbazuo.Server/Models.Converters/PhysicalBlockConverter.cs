using Sbazuo.Engine.Blocks;
using Sbazuo.Server.Models.Responces.Game.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sbazuo.Server.Models.Converters {
	public class PhysicalBlockConverter : Converter {

		public PhysicalBlockInfo Convert(PhysicalBlock block) {
			// TODO replace constantly block id
			return new PhysicalBlockInfo() { BlockId = "physical", Health = block.Health, MaxHealth = block.MaxHealth, OwnerId = block.OwnerId, ShapeId = block.ShapeId, ShapePosition = new Game.Point(block.Position) };
		}

	}
}
