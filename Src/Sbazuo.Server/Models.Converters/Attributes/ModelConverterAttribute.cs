using System;

namespace Sbazuo.Server.Models.Converters.Attributes {
	public class ModelConverterAttribute : Attribute {

		public readonly Type ConverterType;

		public ModelConverterAttribute(Type converterType) {
			this.ConverterType = converterType;
		}

	}
}
