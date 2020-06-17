using Sbazuo.Engine.Blocks;
using Sbazuo.Server.Models.Converters;
using Sbazuo.Server.Models.Converters.Attributes;

namespace Sbazuo.Server.Models.Responces.Game.Blocks {

	[AllowConvert(typeof(PhysicalBlock))]
	[ModelConverter(typeof(PhysicalBlockConverter))]
	public class PhysicalBlockInfo : BlockInfo {

		public int Health { get; set; }

		public int MaxHealth { get; set; }

	}
}
