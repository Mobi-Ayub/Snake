using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	/// <summary>
	/// Food pellet yellow.
	/// </summary>
	class FoodPelletYellow : GamePart
	{
		/// <summary>
		/// Object constructor
		/// </summary>
		/// <param name="X">X coordinate of the food pellet yellow</param>
		/// <param name="Y">Y coordinate of the food pellet yellow</param>
		public FoodPelletYellow(int X, int Y) : base(X, Y)
		{
		}
	}
}
