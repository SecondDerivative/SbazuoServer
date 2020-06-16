using Sbazuo.Geometry;
using Sbazuo.Server.Models.Game;

namespace Sbazuo.Server.Utils {
	internal static class GeometryExtensions {

		public static Vector2D ToVector2D(this Point point) {
			return new Vector2D(point.X, point.Y);
		}

		public static Point2D ToPoint2D(this Point point) {
			return new Point2D(point.X, point.Y);
		}

		public static double GetPolarAngle(this Vector2D vector) {
			return Vector2D.GetAngle(new Vector2D(1, 0), vector);
		}

	}
}
