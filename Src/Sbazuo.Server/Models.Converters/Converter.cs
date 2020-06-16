using Sbazuo.Server.Models.Converters.Contracts;

namespace Sbazuo.Server.Models.Converters {
	public abstract class Converter {

		public IConverterContractResolver Invoker { get; set; }
		
	}
}
