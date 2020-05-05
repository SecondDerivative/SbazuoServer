namespace Sbazuo.Engine {

	/// <summary>
	/// represents object, which has health and can be damaged
	/// </summary>
	public interface IHealthObject {

		/// <summary>
		/// current health
		/// </summary>
		int Health { get; }

		/// <summary>
		/// maximal health
		/// </summary>
		int MaxHealth { get; }

	}
}
