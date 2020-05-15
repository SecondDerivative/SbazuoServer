using System.Collections.Generic;

namespace Sbazuo.Server.Models.Converters.Contracts {
	public interface IConverterContractResolver {

		T Convert<U, T>(U model)
			where U : class
			where T : class;

		T[] ConvertCollection<U, T>(IEnumerable<U> models)
			where U : class
			where T : class;

	}
}
