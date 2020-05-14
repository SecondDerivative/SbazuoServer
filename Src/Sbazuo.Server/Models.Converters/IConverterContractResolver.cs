using System.Collections.Generic;

namespace Sbazuo.Server.Models.Converters {
	public interface IConverterContractResolver {

		T Convert<U, T>(U model);

		T[] ConvertCollection<U, T>(IEnumerable<U> models);

	}
}
