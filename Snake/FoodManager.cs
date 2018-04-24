using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;

namespace Snake
{
	/// <summary>
	/// Manages food pellets, including spawning, destruction, and collision detection
	/// </summary>
	class FoodManager
	{
		private Random r = new Random(); // Used for generating random variables in this class
		private List<FoodPellet> m_FoodPellets = new List<FoodPellet>(); // Collection of food pellets actively in the game
		private List<FoodPelletRed> m_FoodPelletsRed = new List<FoodPelletRed>();
		private List<FoodPelletBlack> m_FoodPelletsBlack = new List<FoodPelletBlack>();
		private List<FoodPelletYellow> m_FoodPelletsYellow = new List<FoodPelletYellow>();
		private List<ObstacleDefault> m_ObstacleDefault = new List<ObstacleDefault>();
		private const int m_CircleRadius = 20; // Determines food pellet size
		private int m_GameWidth; // Game window size in pixels to ensure the program draws within the screen
		private int m_GameHeight; // Game window size in pixels to ensure the program draws within the screen

		/// <summary>
		/// Object constructor
		/// </summary>
		/// <param name="GameWidth">Pixel width of the game window</param>
		/// <param name="GameHeight">Pixel height of the game window</param>
		public FoodManager(int GameWidth, int GameHeight)
		{
			m_GameWidth = GameWidth;
			m_GameHeight = GameHeight;
		}

		/// <summary>
		/// Draws the food pellets
		/// </summary>
		/// <param name="Canvas">Canvas object (game screen) to draw on</param>
		public void Draw(Graphics Canvas)
		{
			// Iterate over all food pellets and draw them
			Brush SnakeColor = Brushes.BlueViolet;
			foreach (FoodPellet Pellet in m_FoodPellets)
			{
				Point PartPos = Pellet.GetPosition();
				Canvas.FillEllipse(SnakeColor, new Rectangle(PartPos.X + (m_CircleRadius / 4), PartPos.Y + (m_CircleRadius / 4), m_CircleRadius / 2, m_CircleRadius / 2));
			}
		}

		public void DrawRed(Graphics Canvas)
		{
			// Iterate over all food pellets and draw them Red
			Brush SnakeColor = Brushes.Red;
			foreach (FoodPelletRed Pellet in m_FoodPelletsRed)
			{
				Point PartPos = Pellet.GetPosition();
				Canvas.FillEllipse(SnakeColor, new Rectangle(PartPos.X + (m_CircleRadius / 4), PartPos.Y + (m_CircleRadius / 4), m_CircleRadius / 2, m_CircleRadius / 2));
			}
		}

		public void DrawBlack(Graphics Canvas)
		{
			// Iterate over all food pellets and draw them Black
			Brush SnakeColor = Brushes.Black;
			foreach (FoodPelletBlack Pellet in m_FoodPelletsBlack)
			{
				Point PartPos = Pellet.GetPosition();
				Canvas.FillEllipse(SnakeColor, new Rectangle(PartPos.X + (m_CircleRadius / 4), PartPos.Y + (m_CircleRadius / 4), m_CircleRadius / 2, m_CircleRadius / 2));

			}
		}

		public void DrawYellow(Graphics Canvas)
		{
			// Iterate over all food pellets and draw them Yellow
			Brush SnakeColor = Brushes.Yellow;
			foreach (FoodPelletYellow Pellet in m_FoodPelletsYellow)
			{
				Point PartPos = Pellet.GetPosition();
				Canvas.FillEllipse(SnakeColor, new Rectangle(PartPos.X + (m_CircleRadius / 4), PartPos.Y + (m_CircleRadius / 4), m_CircleRadius / 2, m_CircleRadius / 2));

			}
		}

		public void DrawObstacle(Graphics Canvas)
		{
			// Iterate over all obstacle and draw them gray
			Brush SnakeColor = Brushes.Gray;
			foreach (ObstacleDefault obstacle in m_ObstacleDefault)
			{
				Point PartPos = obstacle.GetPosition();
				Canvas.FillRectangle(SnakeColor, new Rectangle(PartPos.X + (m_CircleRadius / 2), PartPos.Y + (m_CircleRadius / 2), m_CircleRadius / 1, m_CircleRadius / 1));
			}
		}

		/// <summary>
		/// Adds a food pellet to the game
		/// </summary>
		public void AddRandomFood()
		{
			int X = r.Next(m_GameWidth - m_CircleRadius); // Random x/y positions
			int Y = r.Next(m_GameHeight - m_CircleRadius);
			int ix = (X / m_CircleRadius); //Use truncating to snap to grid
			int iy = Y / m_CircleRadius;
			X = ix * m_CircleRadius; // Grid x/y positions
			Y = iy * m_CircleRadius;
			m_FoodPellets.Add(new FoodPellet(X, Y)); // Save pellet object
		}

		/// <summary>
		/// Adds a red food pellet to the game
		/// </summary>
		public void AddRandomFoodRed()
		{
			int X = r.Next(m_GameWidth - m_CircleRadius);
			int Y = r.Next(m_GameHeight - m_CircleRadius);
			int ix = (X / m_CircleRadius);
			int iy = Y / m_CircleRadius;
			X = ix * m_CircleRadius;
			Y = iy * m_CircleRadius;
			m_FoodPelletsRed.Add(new FoodPelletRed(X, Y));
		}

		/// <summary>
		// Adds a black food pellet to the game
		/// </summary>
		public void AddRandomFoodBlack()
		{
			int X = r.Next(m_GameWidth - m_CircleRadius);
			int Y = r.Next(m_GameHeight - m_CircleRadius);
			int ix = (X / m_CircleRadius);
			int iy = Y / m_CircleRadius;
			X = ix * m_CircleRadius;
			Y = iy * m_CircleRadius;
			m_FoodPelletsBlack.Add(new FoodPelletBlack(X, Y));
		}

		public void AddRandomFoodYellow()
		{
			int X = r.Next(m_GameWidth - m_CircleRadius);
			int Y = r.Next(m_GameHeight - m_CircleRadius);
			int ix = (X / m_CircleRadius);
			int iy = (Y / m_CircleRadius);
			X = ix * m_CircleRadius;
			Y = iy * m_CircleRadius;
			m_FoodPelletsYellow.Add(new FoodPelletYellow(X, Y));
		}

		public void AddRandomObstacleDefault()
		{
			int X = r.Next(m_GameWidth - m_CircleRadius);
			int Y = r.Next(m_GameHeight - m_CircleRadius);
			int ix = (X / m_CircleRadius);
			int iy = (Y / m_CircleRadius);
			X = ix * m_CircleRadius;
			Y = iy * m_CircleRadius;
			m_ObstacleDefault.Add(new ObstacleDefault(X, Y));
		}

		/// <summary>
		/// Override to add food in quantities
		/// </summary>
		/// <param name="Amount">Amount of food to add</param>
		public void AddRandomFood(int Amount)
		{
			for (int i = 0; i < Amount; i++)
			{
				AddRandomFood();
			}
		}

		public void AddRandomFoodRed(int Amount)
		{
			for (int i = 0; i < Amount; i++)
			{
				AddRandomFoodRed();
			}
		}

		public void AddRandomFoodBlack(int Amount)
		{
			for (int i = 0; i < Amount; i++)
			{
				AddRandomFoodBlack();
			}
		}

		public void AddRandomFoodYellow(int Amount)
		{
			for (int i = 0; i < Amount; i++)
			{
				AddRandomFoodYellow();
			}
		}

		public void AddRandomObstacleDefault(int Amount)
		{
			for (int i = 0; i < Amount; i++)
			{
				AddRandomObstacleDefault();
			}
		}

		/// <summary>
		/// Determines whether the given rectangle intersects with any existing food pellets
		/// </summary>
		/// <param name="rect">The rectangle to check for collision with food pellets</param>
		/// <param name="RemoveFood">Whether to remove the food pellets intersecting with the rectangle</param>
		/// <returns>Whether there was an intersection</returns>
		public bool IsIntersectingRect(Rectangle rect, bool RemoveFood)
		{
			foreach (FoodPellet Pellet in m_FoodPellets) // Check each food pellet
			{
				Point PartPos = Pellet.GetPosition();

				// Check rectangle intersection with food pellet
				if (rect.IntersectsWith(new Rectangle(PartPos.X, PartPos.Y, m_CircleRadius, m_CircleRadius)))
				{
					if (RemoveFood) // Remove food pellet if RemoveFood parameter is true
						m_FoodPellets.Remove(Pellet);
					return true;
				}
			}
			return false;
		}

		public bool IsIntersectingRectWithRed(Rectangle rect, bool RemoveFood)
		{
			foreach (FoodPelletRed Pellet in m_FoodPelletsRed)
			{
				Point PartPos = Pellet.GetPosition();

				if (rect.IntersectsWith(new Rectangle(PartPos.X, PartPos.Y, m_CircleRadius, m_CircleRadius)))
				{
					if (RemoveFood)
						m_FoodPelletsRed.Remove(Pellet);
					return true;
				}
			}
			return false;
		}

		public bool IsIntersectingRectWithBlack(Rectangle rect, bool RemoveFood)
		{
			foreach (FoodPelletBlack Pellet in m_FoodPelletsBlack)
			{
				Point PartPos = Pellet.GetPosition();

				if (rect.IntersectsWith(new Rectangle(PartPos.X, PartPos.Y, m_CircleRadius, m_CircleRadius)))
				{
					if (RemoveFood)
						m_FoodPelletsBlack.Remove(Pellet);
					return true;
				}
			}
			return false;
		}

		public bool IsIntersectingRectWithYellow(Rectangle rect, bool RemoveFood)
		{
			foreach (FoodPelletYellow Pellet in m_FoodPelletsYellow)
			{
				Point PartPos = Pellet.GetPosition();

				if (rect.IntersectsWith(new Rectangle(PartPos.X, PartPos.Y, m_CircleRadius, m_CircleRadius)))
				{
					if (RemoveFood)
						m_FoodPelletsYellow.Remove(Pellet);
					return true;
				}
			}
			return false;
		}

		public bool IsIntersectingRectWithObstacleDefault(Rectangle rect, bool RemoveFood)
		{
			foreach (ObstacleDefault obstacle in m_ObstacleDefault)
			{
				Point PartPos = obstacle.GetPosition();

				if (rect.IntersectsWith(new Rectangle(PartPos.X, PartPos.Y, m_CircleRadius + 2, m_CircleRadius + 2)))
				{
					if (RemoveFood)
						m_ObstacleDefault.Remove(obstacle);
					return true;
				}
			}
			return false;
		}

		public void RemoveRandomFood(int where)
		{
			
				m_FoodPellets.RemoveAt(where);
		}

		public void RemoveRandomFoodRed(int where)
		{

			m_FoodPelletsRed.RemoveAt(where);
		}

		public void RemoveRandomFoodBlack(int where)
		{
			m_FoodPelletsBlack.RemoveAt(where);
		}

		public void RemoveRandomFoodYellow(int where)
		{
			m_FoodPelletsYellow.RemoveAt(where);
		}

		public void RemoveRandomObstacleDefault(int where)
		{
			m_ObstacleDefault.RemoveAt(where);
		}

	}
}