using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	/// <summary>
	///  Represents a Power pellet, derived from GamePart
	/// </summary>
	class PowerPellet : GamePart
	{
		/// <summary>
		/// Object constructor
		/// </summary>
		/// <param name="X">X coordinate of the food pellet</param>
		/// <param name="Y">Y coordinate of the food pellet</param>
		public PowerPellet(int X, int Y) : base(X, Y)
		{
		}
	}
}
