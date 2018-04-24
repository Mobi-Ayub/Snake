using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	/// <summary>
	///  Represents an Obstacle, derived from GamePart
	/// </summary>
	class ObstacleDefault : GamePart
	{
		/// <summary>
		/// Object constructor
		/// </summary>
		/// <param name="X">X coordinate of the obstacle</param>
		/// <param name="Y">Y coordinate of the obstacle</param>
		public ObstacleDefault(int X, int Y) : base(X, Y)
		{
		}
	}
}
