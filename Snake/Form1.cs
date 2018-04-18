using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualBasic;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Snake
{
	public partial class SnakeForm : Form, IMessageFilter
	{
		private int counter = 60;
		SnakePlayer Player1;
		FoodManager FoodMngr;
		Random r = new Random();
		private int score = 0;
		private string highscore;

		public SnakeForm()
		{
			InitializeComponent();
			Application.AddMessageFilter(this);
			this.FormClosed += (s, e) => Application.RemoveMessageFilter(this);
			Player1 = new SnakePlayer(this);
			FoodMngr = new FoodManager(GameCanvas.Width, GameCanvas.Height);
			GameTimer.Enabled = false;
			TimerMode.Enabled = false;
			FoodMngr.AddRandomFood(10);
			FoodMngr.AddRandomFoodRed(5);
			GameTimer.Interval = 100;
			TimerMode.Interval = 5000;
			GameCanvas.Invalidate();
			ScoreTxtBox.Text = score.ToString();
			txtHighScore.Text = highscore;
		}

		public void ToggleTimer()
		{
			GameTimer.Enabled = !GameTimer.Enabled;
		}

		public void ResetGame()
		{
			String name, display,filesort, realfile;
			String path = Directory.GetCurrentDirectory();

			if (score != 0)
			{
				GameTimer.Enabled = false;
				display = "Score : " + score.ToString();
				name = Interaction.InputBox(display, "High Scores", "Name", -1, -1);

				while (name.Count() > 3)
					{
						Interaction.MsgBox("Cannot more than 3", MsgBoxStyle.OkOnly);
						name = Interaction.InputBox(display, "High Scores", "Name", -1, -1);
					}

					String line = name + "     " + score.ToString() + Environment.NewLine;
					System.IO.File.AppendAllText(path + "/score.txt", line);
					filesort = path + "/score.txt";
					realfile = path + "/high.txt";
					var content = File.ReadAllLines(filesort);
					Array.Sort(content);
					File.WriteAllLines(realfile, content);

				System.IO.StreamReader hscore = new System.IO.StreamReader(realfile);
				highscore = hscore.ReadLine();
				txtHighScore.Text = highscore;

			}


			Player1 = new SnakePlayer(this);
			FoodMngr = new FoodManager(GameCanvas.Width, GameCanvas.Height);
			score = 0;
		}

		public bool PreFilterMessage(ref Message msg)
		{
			if (msg.Msg == 0x0101) //KeyUp
				Input.SetKey((Keys)msg.WParam, false);
			return false;
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (msg.Msg == 0x100) //KeyDown
				Input.SetKey((Keys)msg.WParam, true);
			
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void GameCanvas_Paint(object sender, PaintEventArgs e)
		{
			Graphics canvas = e.Graphics;
			Player1.Draw(canvas);
			FoodMngr.Draw(canvas);
			FoodMngr.DrawRed(canvas); 
			FoodMngr.DrawBlack(canvas);
			FoodMngr.DrawYellow(canvas);
		}

		private void CheckForCollisions()
		{
			if (Player1.IsIntersectingRect(new Rectangle(-100, 0, 100, GameCanvas.Height)))
				Player1.OnHitWall(Direction.left);

			if (Player1.IsIntersectingRect(new Rectangle(0, -100, GameCanvas.Width, 100)))
				Player1.OnHitWall(Direction.up);

			if (Player1.IsIntersectingRect(new Rectangle(GameCanvas.Width, 0, 100, GameCanvas.Height)))
				Player1.OnHitWall(Direction.right);

			if (Player1.IsIntersectingRect(new Rectangle(0, GameCanvas.Height, GameCanvas.Width, 100)))
				Player1.OnHitWall(Direction.down);

			//Is hitting food
			List<Rectangle> SnakeRects = Player1.GetRects();
			foreach (Rectangle rect in SnakeRects)
			{
				if (FoodMngr.IsIntersectingRect(rect, true))
				{
					FoodMngr.AddRandomFood();
					Player1.AddBodySegments(1);
					score++;
					ScoreTxtBox.Text = score.ToString();
				}

				if (FoodMngr.IsIntersectingRectWithRed(rect, true))
				{
					FoodMngr.AddRandomFoodRed();
					Player1.AddBodySegments(2);
					score+=2;
					ScoreTxtBox.Text = score.ToString();
				}

				if (FoodMngr.IsIntersectingRectWithBlack(rect, true))
				{
					FoodMngr.AddRandomFoodBlack();
					Player1.AddBodySegments(3);
					score+=3;
					ScoreTxtBox.Text = score.ToString();
				}

				if (FoodMngr.IsIntersectingRectWithYellow(rect, true))
				{
					FoodMngr.AddRandomFoodYellow();
					Player1.RemoveBodySegments(1);
					score-=1;
					ScoreTxtBox.Text = score.ToString();
				}
			}
		}

		private void SetPlayerMovement()
		{
			if (Input.IsKeyDown(Keys.A))
			{
				Player1.SetDirection(Direction.left);
			}
			else if (Input.IsKeyDown(Keys.D))
			{
				Player1.SetDirection(Direction.right);
			}
			else if (Input.IsKeyDown(Keys.W))
			{
				Player1.SetDirection(Direction.up);
			}
			else if (Input.IsKeyDown(Keys.S))
			{
				Player1.SetDirection(Direction.down);
			}
			Player1.MovePlayer();
		}

		private void GameTimer_Tick(object sender, EventArgs e)
		{
			
			SetPlayerMovement();
			CheckForCollisions();
			GameCanvas.Invalidate();
		}

		private void TimerMode_Tick(object sender, EventArgs e) { 
			counter--;
			if (GameTimer.Interval > 20 && counter!=0)
			{
                TimerSnake();
			}
			else
				TimerMode.Stop();
		}

		private void TimerSnake() {
			
			if (GameTimer.Interval>25) {
				GameTimer.Interval = GameTimer.Interval - 10;
			}
			if (counter == 58 || counter ==55 || counter==52 || counter==48) {
				FoodMngr.RemoveRandomFood(2);
				FoodMngr.RemoveRandomFood(1);
				FoodMngr.RemoveRandomFoodRed(2);
			}
		}



		private void Start_Btn_Click(object sender, EventArgs e)
		{
			ToggleTimer();

		}

		private void DareBtn_Click(object sender, EventArgs e)
		{
			GameTimer.Enabled = false;
			MessageBox.Show("Have some food :)");
			FoodMngr.AddRandomFood(20);
			GameCanvas.Invalidate();
		}

		private void EasyBtn_Click(object sender, EventArgs e)
		{
			ResetGame();
			GameTimer.Enabled = false;
			FoodMngr.AddRandomFood(10);
			FoodMngr.AddRandomFoodRed(5);
			GameTimer.Interval = 100;
			GameCanvas.Invalidate();
		}

		private void HardBtn_Click(object sender, EventArgs e)
		{
			ResetGame();
			GameTimer.Enabled = false;
			FoodMngr.AddRandomFood(15);
			FoodMngr.AddRandomFoodRed(5);
			FoodMngr.AddRandomFoodBlack(5);
			FoodMngr.AddRandomFoodYellow(5);
			GameTimer.Interval = 50;
			GameCanvas.Invalidate();
		}

		private void ImpossibleBtn_Click(object sender, EventArgs e)
		{
			ResetGame();
			GameTimer.Enabled = false;
			FoodMngr.AddRandomFood(20);
			FoodMngr.AddRandomFoodRed(10);
			FoodMngr.AddRandomFoodBlack(5);
			FoodMngr.AddRandomFoodYellow(5);
			GameTimer.Interval = 25;
			GameCanvas.Invalidate();
		}

		private void TimerBtn_Click(object sender, EventArgs e)
		{
			ResetGame();
			GameTimer.Interval = 100;
			TimerMode.Start();
			TimerMode.Enabled = true;
			GameTimer.Enabled = false;
			FoodMngr.AddRandomFood(15);
			FoodMngr.AddRandomFoodRed(5);
			FoodMngr.AddRandomFoodBlack(5);
			FoodMngr.AddRandomFoodYellow(5);
			GameCanvas.Invalidate();
		}

        private void DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(DropDown.SelectedIndex)
            {
                case 0:
                    this.btnChange.Click += new System.EventHandler(this.EasyBtn_Click);
                    break;
                case 1:
                    this.btnChange.Click += new System.EventHandler(this.HardBtn_Click);
                    break;
                case 2:
                    this.btnChange.Click += new System.EventHandler(this.ImpossibleBtn_Click);
                    break;
                case 3:
                    this.btnChange.Click += new System.EventHandler(this.TimerBtn_Click);
                    break;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
        }
    }
}
