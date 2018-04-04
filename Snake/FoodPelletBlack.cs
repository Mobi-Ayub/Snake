using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	/// <summary>
	/// Food pellet black.
	/// </summary>
	class FoodPelletBlack : GamePart
	{
		/// <summary>
		/// Object constructor
		/// </summary>
		/// <param name="X">X coordinate of the food pellet Black</param>
		/// <param name="Y">Y coordinate of the food pellet Black</param>
		public FoodPelletBlack(int X, int Y) : base(X, Y)
		{
		}
	}
}
