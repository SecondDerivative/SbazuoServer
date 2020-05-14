using System.Collections.Generic;
using System.Linq;

namespace Sbazuo.Server.Models.Converters {
	public class DefaultConverterContractResolver : IConverterContractResolver {
		
		public T Convert<U, T>(U model) {
			
		}

		public T[] ConvertCollection<U, T>(IEnumerable<U> models) {
			return models.Select(x => Convert<U, T>(x)).ToArray();
		}
	}
}
