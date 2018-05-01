﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Snake
{
	/// <summary>
	/// Directional representation of player

	/// <summary>
	/// Class containing the controller logic for the player
	/// </summary>
	class SnakePlayerTwo
	{
		private List<BodyPart> m_SnakeParts = new List<BodyPart>(); // Collection of current snake body parts
		private const int m_CircleRadius = 20; // Determines body part size
		private Direction m_MoveDirection = Direction.none; // Direction of the head
		private int m_PendingSegments; // Number of body parts in queue to be added to the snake
		private int m_PendingRSegments; // Number of body parts in queue to be removed from the snake
		private SnakeForm GameForm = null; // Stores the GUI form

		/// <summary>
		/// Object constructor
		/// </summary>
		/// <param name="Form">GUI form for the game</param>
		public SnakePlayerTwo(SnakeForm Form)
		{
			// Add 3 body parts to the snake because the snake begins small
			m_SnakeParts.Add(new BodyPart(100, 0, Direction.right));
			m_SnakeParts.Add(new BodyPart(80, 0, Direction.right));
			m_SnakeParts.Add(new BodyPart(60, 0, Direction.right));

			// Need to give an initial direction
			m_MoveDirection = Direction.right;

			// Currently no body parts queued to be added / removed
			m_PendingSegments = 0;
			m_PendingRSegments = 0;
			GameForm = Form;
		}

		/// <summary>
		/// Moves the snake and processes any pending body segments to be created. Called every frame.
		/// </summary>
		public void MovePlayer()
		{
			// Adds any pending body parts. Note that this processes one body part at a time;
			// if m_PendingSegments > 1, it will require more than one frame to process completely.
			if (m_PendingSegments > 0)
			{
				Point LastPos = m_SnakeParts.Last().GetPosition(); // Adds the body part to the tail
				m_SnakeParts.Add(new BodyPart(LastPos.X, LastPos.Y));
				m_PendingSegments--;
			}

			if (m_PendingRSegments > 0)
			{
				if (m_SnakeParts.Count >= 3)
				{
					m_SnakeParts.RemoveAt(m_SnakeParts.Count - 1);
					m_PendingRSegments--;
				}
				m_PendingRSegments--;
			}

			m_SnakeParts[0].m_Dir = m_MoveDirection; // Set the head direction

			// Moves each snake body part
			for (int i = m_SnakeParts.Count - 1; i >= 0; i--)
			{
				// Translates the body part in accordance with its direction
				switch (m_SnakeParts[i].m_Dir)
				{
					case Direction.left:
						m_SnakeParts[i].AddPosition(new Point(-20, 0));
						break;
					case Direction.right:
						m_SnakeParts[i].AddPosition(new Point(20, 0));
						break;
					case Direction.down:
						m_SnakeParts[i].AddPosition(new Point(0, 20));
						break;
					case Direction.up:
						m_SnakeParts[i].AddPosition(new Point(0, -20));
						break;
					default:
						break;
				}

				// Set the direction of the next part to be the direction of the previous
				// for snake-like movement
				if (i > 0)
					m_SnakeParts[i].m_Dir = m_SnakeParts[i - 1].m_Dir;
			}
			if (IsSelfIntersecting()) // Check for collisions with itself
			{
				SoundPlayer srecthit = new SoundPlayer(Snake.Properties.Resources.bite);
				srecthit.Play();
				OnHitSelf(); // If so, trigger the game-over screen
			}
		}

		/// <summary>
		/// Determines whether the snake is intersecting with itself
		/// </summary>
		/// <returns>Whether the snake is intersecting with itself</returns>
		public bool IsSelfIntersecting()
		{
			// Check each snake body part with every other snake body part
			for (int i = 0; i < m_SnakeParts.Count; i++)
			{
				for (int j = 0; j < m_SnakeParts.Count; j++)
				{
					if (i == j) // Do not want to check a body part with itself
						continue;
					BodyPart part1 = m_SnakeParts[i];
					BodyPart part2 = m_SnakeParts[j];

					// Collision check logic
					if ((new Rectangle(part1.GetPosition().X, part1.GetPosition().Y, m_CircleRadius, m_CircleRadius)).IntersectsWith(
						new Rectangle(part2.GetPosition().X, part2.GetPosition().Y, m_CircleRadius, m_CircleRadius)))
						return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Determines whether any body part is intersecting with the given rectangle
		/// </summary>
		/// <param name="rect">The rectangle to check intsections with</param>
		/// <returns>Whether there was an intersection</returns>
		public bool IsIntersectingRect(Rectangle rect)
		{
			foreach (BodyPart Part in m_SnakeParts) // Check each snake body part
			{
				Point PartPos = Part.GetPosition();

				// Check rectangle intersection with body part
				if (rect.IntersectsWith(new Rectangle(PartPos.X, PartPos.Y, m_CircleRadius, m_CircleRadius)))
					return true;
			}
			return false;
		}

		/// <summary>
		/// Displays the game-over screen in the case that the player hits themself
		/// </summary>
		public void OnHitSelf()
		{
			GameForm.ToggleTimer(); // No timer visible on game-over screen
			MessageBox.Show("Hit SELF- GAME OVER"); // Display game-over message
			GameForm.ResetGame();
		}

		/// <summary>
		/// Displays the game-over screen in the case that the player hits the wall
		/// </summary>
		/// <param name="WhichWall">The direction of the wall that the player hit</param>
		public void OnHitWall(Direction WhichWall)
		{
			GameForm.ToggleTimer(); // No timer visible on game-over screen 
			MessageBox.Show("Hit Wall- GAME OVER"); // Display game-over message
			GameForm.ResetGame();
		}

		public void OnHitObstacle()
		{
			GameForm.ToggleTimer(); // No timer visible on game-over screen
			SoundPlayer srecthit = new SoundPlayer(Snake.Properties.Resources.hit);
			srecthit.Play();
			MessageBox.Show("Hit Obstacle- GAME OVER"); // Display game-over message
			GameForm.ResetGame();
		}

		/// <summary>
		/// Sets the direction of the snake head
		/// </summary>
		/// <param name="Dir">Direction to set the head to</param>
		public void SetDirection(Direction Dir)
		{
			// Forbid 180 degree turns
			if (m_MoveDirection == Direction.left && Dir == Direction.right)
				return;

			if (m_MoveDirection == Direction.right && Dir == Direction.left)
				return;

			if (m_MoveDirection == Direction.up && Dir == Direction.down)
				return;

			if (m_MoveDirection == Direction.down && Dir == Direction.up)
				return;

			// Set the direction if the direction change is legal
			m_MoveDirection = Dir;
		}

		/// <summary>
		/// Called per frame to render the snake body parts
		/// </summary>
		/// <param name="canvas">The graphics object to render on</param>
		public void Draw(Graphics canvas)
		{
			Brush SnakeColor = Brushes.Azure;
			List<Rectangle> Rects = GetRects(); // Get the snake body parts, represented as rectangles
												//Image img = Image.FromFile("C:\\Users\\ASUS\\Documents\\Swinburne Study\\Degree\\Year2\\Sem 1\\DP1-Tool\\Assignment\\Snake\\Snake\\Images\\Snake.png");

			foreach (Rectangle Part in Rects) // Draw each snake body part
			{
				canvas.FillEllipse(SnakeColor, Part); // Draw the snake parts as ellipses
			}
			Brush HeadColor = Brushes.Chocolate;

			//canvas.DrawImageUnscaledAndClipped(img , Rects[0]);
			canvas.FillEllipse(HeadColor, Rects[0]);
			canvas.FillEllipse(HeadColor, Rects[1]);
		}

		/// <summary>
		/// Adds snake body parts
		/// </summary>
		/// <param name="Number">Number of body parts to add</param>
		public void AddBodySegments(int Number)
		{
			// Increments m_PendingSegments as it will be processed and the parts added in the next call to MovePlayer()
			m_PendingSegments += Number;
		}

		public void RemoveBodySegments(int Number)
		{
			m_PendingRSegments += Number;
		}

		/// <summary>
		/// Gets the snake body parts, represented as rectangles
		/// </summary>
		/// <returns>A list of snake body parts represented as rectangles</returns>
		public List<Rectangle> GetRects()
		{
			List<Rectangle> Rects = new List<Rectangle>();
			foreach (BodyPart Part in m_SnakeParts) // Return all body parts
			{
				Point PartPos = Part.GetPosition();

				// Every iteration, add a rectangle to the ongoing list representing the body part
				Rects.Add(new Rectangle(PartPos.X, PartPos.Y, m_CircleRadius, m_CircleRadius));
			}
			return Rects;
		}

	}
}