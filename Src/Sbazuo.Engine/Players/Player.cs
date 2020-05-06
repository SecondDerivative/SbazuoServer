using Sbazuo.Geometry;

namespace Sbazuo.Engine.Players {

	/// <summary>
	/// represents information about player
	/// </summary>
	public class Player {

		/// <summary>
		/// gets player unique id
		/// </summary>
		public readonly string Id;

		/// <summary>
		/// gets or sets projectile catapult position
		/// </summary>
		public Point2D CatapultPosition { get; set; }

		/// <summary>
		/// create new instance of <see cref="Player"/>
		/// </summary>
		/// <param name="id"> player's unique id </param>
		public Player(string id) {
			this.Id = id;
		}



	}
}
