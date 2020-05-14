using Sbazuo.Geometry;
using System.Collections.Generic;
using System.Linq;

namespace Sbazuo.Engine.GameMaps {

	/// <summary>
	/// represents simple rectangle game field for 4 players
	/// </summary>
	public class RectangleMap : GameMap {

		public readonly double GameFieldWidth;

		public readonly double GameFieldHeight;

		public RectangleMap(string id, double width, double height) : base(id,
																	 new Shape2D(new Point2D[] { new Point2D(0, 0), new Point2D(0, height), new Point2D(width, height), new Point2D(width, 0) }),
																	 null) {

			IDictionary<string, Shape2D> areas = new Dictionary<string, Shape2D>();
			areas.Add("1", new Shape2D(new Point2D[] { new Point2D(0, 0), new Point2D(width / 2, 0), new Point2D(width / 2, height / 2), new Point2D(0, height / 2) }));
			areas.Add("2", new Shape2D(new Point2D[] { new Point2D(0, height / 2), new Point2D(width / 2, height / 2), new Point2D(width / 2, height), new Point2D(0, height) }));
			areas.Add("3", new Shape2D(new Point2D[] { new Point2D(width / 2, 0), new Point2D(width, 0), new Point2D(width, height / 2), new Point2D(width / 2, height / 2) }));
			areas.Add("4", new Shape2D(new Point2D[] { new Point2D(height / 2, height / 2), new Point2D(width, height / 2), new Point2D(width, height), new Point2D(width / 2, height) }));
			
			this.Areas = areas;
			this.GameFieldWidth = width;
			this.GameFieldHeight = height;
		}

		public override IDictionary<string, Point2D> GetPlayerCatapults(IEnumerable<string> playerIds) {

			int playerCount = playerIds.Count();
			
			// 1/4 part of width
			double w14 = GameFieldWidth / 4;
			// 3/4 part of width
			double w34 = GameFieldWidth / 2 + w14;
			// 1/4 part of height
			double h14 = GameFieldHeight / 4;
			// 3/4 part of height
			double h34 = GameFieldHeight / 2 + h14;

			string[] ids = playerIds.ToArray();
			Point2D[] points = new Point2D[] { new Point2D(w14, h14), new Point2D(w14, h34), new Point2D(w34, h14), new Point2D(w34, h34) };
			IDictionary<string, Point2D> result = new Dictionary<string, Point2D>();
			for (int i = 0; i < playerCount; ++i) {
				result.Add(ids[i], points[i]);
			}
			return result;
		}

		public override IDictionary<string, string> GetPlayersAreas(IEnumerable<string> playerIds) {
			IDictionary<string, string> result = new Dictionary<string, string>();
			string[] ids = playerIds.ToArray();
			result.Add("1", ids[0]);
			result.Add("2", ids[1]);
			result.Add("3", ids[2]);
			result.Add("4", ids[3]);
			return result;
		}

	}
}
