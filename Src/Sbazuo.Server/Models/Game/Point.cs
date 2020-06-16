using Sbazuo.Geometry;
using System.ComponentModel.DataAnnotations;

namespace Sbazuo.Server.Models.Game {
	public class Point {

		[Required]
		public double X;

		[Required]
		public double Y;

		public Point() {

		}

		public Point(Point2D point) {
			X = point.X;
			Y = point.Y;
		}

		public Point(Vector2D vector) {
			X = vector.X;
			Y = vector.Y;
		}
	}
}
