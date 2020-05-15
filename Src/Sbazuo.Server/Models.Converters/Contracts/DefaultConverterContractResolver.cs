using Sbazuo.Server.Models.Converters.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sbazuo.Server.Models.Converters.Contracts {
	public class DefaultConverterContractResolver : IConverterContractResolver {

		public object Convert(object model, Type convertedType) {
			Type modelType = model.GetType();
			Type[] possibleTypes =
#if DEBUG
				AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(x => x.GetTypes())
				.Distinct()
#else
				Assembly.GetExecutingAssembly()
				.GetTypes()
#endif
				.Where(x => x.IsSubclassOf(convertedType) && !x.IsAbstract)
				.Append(convertedType)
				//.Distinct()
				.ToArray();
			//Console.WriteLine("total found possible types " + possibleTypes.Length);
			foreach (var type in possibleTypes) {
				AllowConvertAttribute allowedTypes = type.GetCustomAttribute<AllowConvertAttribute>();
				ModelConverterAttribute converterAttribute = type.GetCustomAttribute<ModelConverterAttribute>();
				if (converterAttribute == null) {
					continue;
				}
				if (allowedTypes.ConvertedType.Where(x => x == modelType).Count() > 0) {
					//Console.WriteLine("founded converter " + converterAttribute.ConverterType.FullName + " begin convert");
					return (Activator.CreateInstance(converterAttribute.ConverterType) as IConverter).Convert(model);
				}
			}
			//Console.WriteLine("converters not found");
			return default;
		}

		public T Convert<U, T>(U model) where U : class
										where T : class {

			return Convert(model, typeof(T)) as T;
		}

		public T[] ConvertCollection<U, T>(IEnumerable<U> models) where U : class
																  where T : class {
			return models.Select(x => Convert<U, T>(x)).ToArray();
		}
	}
}
