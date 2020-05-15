using System;

namespace Sbazuo.Server.Models.Converters.Attributes {

	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public class AllowConvertAttribute : Attribute {

		public Type[] ConvertedType { get; set; }

		public AllowConvertAttribute(params Type[] convertedType) {
			this.ConvertedType = convertedType;		
		}

	}
}
