using System;
using System.Text;

namespace Sbazuo.Server.Utils {
	internal static class StringGenerator {

		private static Random Rand = new Random();

		private const int DefaultLength = 32;

		public static string GenerateString(int length = DefaultLength) {
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < length; ++i) {
				builder.Append(GenerateChar());
			}
			return builder.ToString();
		}

		private static char GenerateChar() {
			int index = Rand.Next(62);
			if (index < 26) {
				return (char)('a' + index);
			}
			if (index < 52) {
				return (char)('A' + index - 26);
			}
			return (char)('0' + index - 52);
		}

	}
}
