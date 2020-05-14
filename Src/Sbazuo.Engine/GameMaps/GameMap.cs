using Sbazuo.Geometry;
using System.Collections.Generic;

namespace Sbazuo.Engine.GameMaps {

	/// <summary>
	/// represents information about game field
	/// </summary>
	public abstract class GameMap {

		/// <summary>
		/// geometry of game field
		/// </summary>
		public Shape2D GameField { get; set; }

		/// <summary>
		/// dictionary of areas
		/// key - area id
		/// value - area geometry
		/// </summary>
		public IDictionary<string, Shape2D> Areas { get; set; }

		/// <summary>
		/// map's unique id
		/// </summary>
		public readonly string MapId;

		/// <summary>
		/// create new instance of <see cref="GameMap"/>
		/// </summary>
		/// <param name="id"> map's unique id </param>
		/// <param name="field"> geometry of game field </param>
		/// <param name="areas"> player's possible areas </param>
		public GameMap(string id, Shape2D field, IDictionary<string, Shape2D> areas) {
			this.MapId = id;
			this.GameField = field;
			this.Areas = areas;
		}

		/// <summary>
		/// returns player areas
		/// </summary>
		/// <returns>
		/// dictionary of player own areas
		/// key - area's id
		/// value - player's id
		/// </returns>
		public abstract IDictionary<string, string> GetPlayersAreas(IEnumerable<string> playerIds);

		/// <summary>
		/// returns player catapult positions
		/// </summary>
		/// <returns>
		/// dictionary of player catapults
		/// key - player's id
		/// value - catapult position
		/// </returns>
		public abstract IDictionary<string, Point2D> GetPlayerCatapults(IEnumerable<string> playerIds);

	}
}
