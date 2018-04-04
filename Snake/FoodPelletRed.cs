using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	/// <summary>
	/// Food pellet red.
	/// </summary>
	class FoodPelletRed : GamePart
	{
		/// <summary>
		/// Object constructor
		/// </summary>
		/// <param name="X">X coordinate of the food pellet Red</param>
		/// <param name="Y">Y coordinate of the food pellet Red</param>
		public FoodPelletRed(int X, int Y) : base(X, Y)
		{
		}
	}
}
