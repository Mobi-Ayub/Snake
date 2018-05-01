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
using System.Media;

namespace Snake
{
	public partial class SnakeForm : Form, IMessageFilter
	{
		private int counter = 60;
		private int time = 0;
		SnakePlayer Player1;
        SnakePlayerTwo Player2;
        FoodManager FoodMngr;
		Random r = new Random();
		private int score = 0;
		private string highscore;
		private int powerCounter = 0;

		public SnakeForm()
		{
			InitializeComponent();
			Application.AddMessageFilter(this);
			this.FormClosed += (s, e) => Application.RemoveMessageFilter(this);
			Player1 = new SnakePlayer(this);
            Player2 = new SnakePlayerTwo(this);
            FoodMngr = new FoodManager(GameCanvas.Width, GameCanvas.Height);
			GameTimer.Enabled = false;
			TimerMode.Enabled = false;
			TimeCount.Enabled = false;
			FoodMngr.AddRandomFood(10);
			FoodMngr.AddRandomFoodRed(5);
			GameTimer.Interval = 100;
			TimeCount.Interval = 1000;
			TimerMode.Interval = 5000;
			GameCanvas.Invalidate();
			ScoreTxtBox.Text = score.ToString();
			txtHighScore.Text = highscore;
        }

		public void ToggleTimer()
		{
			GameTimer.Enabled = !GameTimer.Enabled;
			TimeCount.Enabled = !TimeCount.Enabled;
        }

		public void ResetGame()
        {
            time = 0;
            String name, display, filesort, realfile, first, score1, real, rs;
            int s1, hs;
            long[] array;
            string temp3, temp4;
            
			long sc,t;
            String path = Directory.GetCurrentDirectory();

            if (score != 0)
            {
                if (score < 10)
                {
                    rs = " " + score.ToString();
                }
                else
                {
                    rs = score.ToString();
                }
                GameTimer.Enabled = false;
                display = "Score : " + rs;
                name = Interaction.InputBox(display, "High Scores", "Name", -1, -1);

                while (name.Count() > 3)
                {
                    Interaction.MsgBox("Cannot more than 3", MsgBoxStyle.OkOnly);
                    name = Interaction.InputBox(display, "High Scores", "Name", -1, -1);
                }

                String line = rs + "\t     " + name + Environment.NewLine;
                System.IO.File.AppendAllText(path + "/score.txt", line);
                filesort = path + "/score.txt";
                realfile = path + "/high.txt";
                var content = File.ReadAllLines(filesort);
                Array.Sort(content);
                Array.Reverse(content);
                File.Delete(filesort);
                for (int i = 0; i < content.Count(); i++)
                {
                    File.AppendAllText(filesort, content[i] + Environment.NewLine);
                }

                array = new long[content.Count()];

                for (int i = 0; i < content.Count(); i++)
                {
                    temp3 = content[i];
                    temp4 = String.Concat(temp3[0], temp3[1]);
					sc = Int64.Parse(temp4);
                    array[i] = sc;
                }

                for (long j = 0; j < array.Length; j++)
                {
                    for (long k = 0; k < array.Length - 1; k++)
                    {
                        if (array[k] > array[k + 1])
                        {
                            t = array[k + 1];
                            array[k + 1] = array[k];
                            array[k] = t;
                        }
                    }
                }





                first = content[0];
                score1 = String.Concat(first[0], first[1]);
                s1 = Convert.ToInt32(score1);
                hs = s1;
                real = content[0];
                for (int i = 0; i < content.Count(); i++)
                {
                    string second, score2, temp, temp2;
                    int s2, s;

                    second = content[i];

                    score2 = String.Concat(second[0], second[1]);

                    s2 = Convert.ToInt32(score2);

                    if (hs < s2)
                    {
                        hs = s2;
                    }

                    temp = content[i];
                    temp2 = String.Concat(temp[0], temp[1]);
                    s = Convert.ToInt32(temp2);
                    if (s == hs)
                    {
                        real = content[i];
                    }

                }

                File.WriteAllText(realfile, String.Empty);

                File.AppendAllText(realfile, real);


                System.IO.StreamReader hscore = new System.IO.StreamReader(filesort);
                highscore = hscore.ReadLine();
                txtHighScore.Text = highscore;

            }


            Player1 = new SnakePlayer(this);
            Player2 = new SnakePlayerTwo(this);
            FoodMngr = new FoodManager(GameCanvas.Width, GameCanvas.Height);
            score = 0;
        }

		public void _2PGameReset()
		{
			time = 0;
			MessageBox.Show("Winner!! \n\n Player 1");
			Player1 = new SnakePlayer(this);
			Player2 = new SnakePlayerTwo(this);
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
            Player2.Draw(canvas);
			FoodMngr.Draw(canvas);
			FoodMngr.DrawRed(canvas); 
			FoodMngr.DrawBlack(canvas);
			FoodMngr.DrawYellow(canvas);
			FoodMngr.DrawObstacle(canvas);
			FoodMngr.DrawPower(canvas);
		}

        //Is hitting wall
		private void CheckForCollisions()
		{
			if (Player1.IsIntersectingRect(new Rectangle(-100, 0, 100, GameCanvas.Height)))
            {
                SoundPlayer srecthit = new SoundPlayer(Snake.Properties.Resources.hit);
                srecthit.Play();
                Player1.OnHitWall(Direction.left);
            }

			if (Player1.IsIntersectingRect(new Rectangle(0, -100, GameCanvas.Width, 100)))
            {
                SoundPlayer srecthit = new SoundPlayer(Snake.Properties.Resources.hit);
                srecthit.Play();
                Player1.OnHitWall(Direction.up);
            }

            if (Player1.IsIntersectingRect(new Rectangle(GameCanvas.Width, 0, 100, GameCanvas.Height)))
            {
                SoundPlayer srecthit = new SoundPlayer(Snake.Properties.Resources.hit);
                srecthit.Play();
                Player1.OnHitWall(Direction.right);
            }

			if (Player1.IsIntersectingRect(new Rectangle(0, GameCanvas.Height, GameCanvas.Width, 100)))
            {
                SoundPlayer srecthit = new SoundPlayer(Snake.Properties.Resources.hit);
                srecthit.Play();
                Player1.OnHitWall(Direction.down);
            }

			//Is hitting food
			List<Rectangle> SnakeRects = Player1.GetRects();
			foreach (Rectangle rect in SnakeRects)
			{
				if (FoodMngr.IsIntersectingRect(rect, true))
				{
					FoodMngr.AddRandomFood();
					Player1.AddBodySegments(1);
					powerCounter+=1;
					score++;
					ScoreTxtBox.Text = score.ToString();
					SoundPlayer srect = new SoundPlayer(Snake.Properties.Resources.normal);
					srect.Play();
				}

				if (FoodMngr.IsIntersectingRectWithRed(rect, true))
				{
					FoodMngr.AddRandomFoodRed();
					Player1.AddBodySegments(2);
					powerCounter+=1;
					score+=2;
					ScoreTxtBox.Text = score.ToString();
					SoundPlayer srectRed = new SoundPlayer(Snake.Properties.Resources.red);
                    srectRed.Play();
				}

				if (FoodMngr.IsIntersectingRectWithBlack(rect, true))
				{
					FoodMngr.AddRandomFoodBlack();
					Player1.AddBodySegments(3);
					powerCounter+=1;
					score+=3;
					ScoreTxtBox.Text = score.ToString();
					SoundPlayer srectBlack = new SoundPlayer(Snake.Properties.Resources.red);
					srectBlack.Play();
				}

				if (FoodMngr.IsIntersectingRectWithYellow(rect, true))
				{
					for (int i = time; i < time + 4;i++) {
						SetPlayerMovement();
					}
					FoodMngr.AddRandomFoodYellow();
					Player1.RemoveBodySegments(1);
					score-=1;
					ScoreTxtBox.Text = score.ToString();
					SoundPlayer srectYellow = new SoundPlayer(Snake.Properties.Resources.yellow);
					srectYellow.Play();
				}

				if (FoodMngr.IsIntersectingRectWithObstacleDefault(rect, true))
				{
					FoodMngr.AddRandomObstacleDefault();
					Player1.OnHitObstacle();
					ScoreTxtBox.Text = score.ToString();
				}

				if (FoodMngr.IsIntersectingRectWithPower(rect, true))
				{
					FoodMngr.AddRandomPower();
					Player1.OnHitPower();
					ScoreTxtBox.Text = score.ToString();

				}

				if (powerCounter >= 5)
				{
					Player1.OnUnHitPower();
					powerCounter = 0;
				}
			}
		}

		private void SetPlayerMovement()
		{
			if (Input.IsKeyDown(Keys.A))
			{
                SoundPlayer srectT = new SoundPlayer(Snake.Properties.Resources.turn);
                srectT.Play();
                Player1.SetDirection(Direction.left);
            }
			else if (Input.IsKeyDown(Keys.D))
			{
                SoundPlayer srectT = new SoundPlayer(Snake.Properties.Resources.turn);
                srectT.Play();
                Player1.SetDirection(Direction.right);
            }
			else if (Input.IsKeyDown(Keys.W))
			{
                SoundPlayer srectT = new SoundPlayer(Snake.Properties.Resources.turn);
                srectT.Play();
                Player1.SetDirection(Direction.up);
            }
			else if (Input.IsKeyDown(Keys.S))
			{
                SoundPlayer srectT = new SoundPlayer(Snake.Properties.Resources.turn);
                srectT.Play();
                Player1.SetDirection(Direction.down);
            }
			Player1.MovePlayer();
		}

        //Is hitting wall Second Player
        private void CheckForCollisionsSecond()
        {
            if (Player2.IsIntersectingRect(new Rectangle(-100, 0, 100, GameCanvas.Height)))
            {
                SoundPlayer srecthit = new SoundPlayer(Snake.Properties.Resources.hit);
                srecthit.Play();
                Player2.OnHitWall(Direction.left);
            }

            if (Player2.IsIntersectingRect(new Rectangle(0, -100, GameCanvas.Width, 100)))
            {
                SoundPlayer srecthit = new SoundPlayer(Snake.Properties.Resources.hit);
                srecthit.Play();
                Player2.OnHitWall(Direction.up);
            }

            if (Player2.IsIntersectingRect(new Rectangle(GameCanvas.Width, 0, 100, GameCanvas.Height)))
            {
                SoundPlayer srecthit = new SoundPlayer(Snake.Properties.Resources.hit);
                srecthit.Play();
                Player2.OnHitWall(Direction.right);
            }

            if (Player2.IsIntersectingRect(new Rectangle(0, GameCanvas.Height, GameCanvas.Width, 100)))
            {
                SoundPlayer srecthit = new SoundPlayer(Snake.Properties.Resources.hit);
                srecthit.Play();
                Player2.OnHitWall(Direction.down);
            }

            //Is hitting food
            List<Rectangle> SnakeRects = Player2.GetRects();
            foreach (Rectangle rect in SnakeRects)
            {
                if (FoodMngr.IsIntersectingRect(rect, true))
                {
                    FoodMngr.AddRandomFood();
                    Player2.AddBodySegments(1);
                    score++;
                    ScoreTxtBox.Text = score.ToString();
                    SoundPlayer srect = new SoundPlayer(Snake.Properties.Resources.normal);
                    srect.Play();
                }

                if (FoodMngr.IsIntersectingRectWithRed(rect, true))
                {
                    FoodMngr.AddRandomFoodRed();
                    Player2.AddBodySegments(2);
                    score += 2;
                    ScoreTxtBox.Text = score.ToString();
                    SoundPlayer srectRed = new SoundPlayer(Snake.Properties.Resources.red);
                    srectRed.Play();
                }

                if (FoodMngr.IsIntersectingRectWithBlack(rect, true))
                {
                    FoodMngr.AddRandomFoodBlack();
                    Player2.AddBodySegments(3);
                    score += 3;
                    ScoreTxtBox.Text = score.ToString();
                    SoundPlayer srectBlack = new SoundPlayer(Snake.Properties.Resources.red);
                    srectBlack.Play();
                }

                if (FoodMngr.IsIntersectingRectWithYellow(rect, true))
                {
                    FoodMngr.AddRandomFoodYellow();
                    Player2.RemoveBodySegments(1);
                    score -= 1;
                    ScoreTxtBox.Text = score.ToString();
                    SoundPlayer srectYellow = new SoundPlayer(Snake.Properties.Resources.yellow);
                    srectYellow.Play();
                }

                if (FoodMngr.IsIntersectingRectWithObstacleDefault(rect, true))
                {
                    FoodMngr.AddRandomObstacleDefault();
                    Player2.OnHitObstacle();
                    ScoreTxtBox.Text = score.ToString();
                }
            }
        }

        private void SetPlayerTwoMovement()
        {
            if (Input.IsKeyDown(Keys.Left))
            {
                SoundPlayer srectT = new SoundPlayer(Snake.Properties.Resources.turn);
                srectT.Play();
                Player2.SetDirection(Direction.left);
            }
            else if (Input.IsKeyDown(Keys.Right))
            {
                SoundPlayer srectT = new SoundPlayer(Snake.Properties.Resources.turn);
                srectT.Play();
                Player2.SetDirection(Direction.right);
            }
            else if (Input.IsKeyDown(Keys.Up))
            {
                SoundPlayer srectT = new SoundPlayer(Snake.Properties.Resources.turn);
                srectT.Play();
                Player2.SetDirection(Direction.up);
            }
            else if (Input.IsKeyDown(Keys.Down))
            {
                SoundPlayer srectT = new SoundPlayer(Snake.Properties.Resources.turn);
                srectT.Play();
                Player2.SetDirection(Direction.down);
            }
            Player2.MovePlayer();
        }

        private void SetPlayerMovement2()
		{
			if (Input.IsKeyDown(Keys.A))
			{
				SoundPlayer srectT = new SoundPlayer(Snake.Properties.Resources.turn);
				srectT.Play();
				Player1.SetDirection(Direction.right);
			}
			else if (Input.IsKeyDown(Keys.D))
			{
				SoundPlayer srectT = new SoundPlayer(Snake.Properties.Resources.turn);
				srectT.Play();
				Player1.SetDirection(Direction.left);
			}
			else if (Input.IsKeyDown(Keys.W))
			{
				SoundPlayer srectT = new SoundPlayer(Snake.Properties.Resources.turn);
				srectT.Play();
				Player1.SetDirection(Direction.down);
			}
			else if (Input.IsKeyDown(Keys.S))
			{
				SoundPlayer srectT = new SoundPlayer(Snake.Properties.Resources.turn);
				srectT.Play();
				Player1.SetDirection(Direction.up);
			}
			Player1.MovePlayer();
		}

		private void GameTimer_Tick(object sender, EventArgs e)
		{
			if (DropDown.Text == "Reverse")
			{
                SetPlayerMovement2();
			}
			else
			{
				SetPlayerMovement();
                SetPlayerTwoMovement();
            }
			CheckForCollisions();
            CheckForCollisionsSecond();
			GameCanvas.Invalidate();
		}

		private void TimeCount_Tick(object sender, EventArgs e)
		{
			time++;
        if (time == 0)
				TimeCount.Stop();
        txtTime.Text = time.ToString();
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
            Player2.RemoveSnake();
            ResetGame();
			GameTimer.Enabled = false;
			FoodMngr.AddRandomFood(10);
			FoodMngr.AddRandomFoodRed(5);
			FoodMngr.AddRandomPower(2);
			GameTimer.Interval = 100;
			GameCanvas.Invalidate();
		}

		private void HardBtn_Click(object sender, EventArgs e)
		{
            Player2.RemoveSnake();
            ResetGame();
			GameTimer.Enabled = false;
			FoodMngr.AddRandomFood(20);
			FoodMngr.AddRandomFoodRed(5);
			FoodMngr.AddRandomFoodBlack(5);
			FoodMngr.AddRandomFoodYellow(5);
			FoodMngr.AddRandomObstacleDefault(5);
			FoodMngr.AddRandomPower(2);
			GameTimer.Interval = 50;
			GameCanvas.Invalidate();
		}

		private void ImpossibleBtn_Click(object sender, EventArgs e)
		{
            Player2.RemoveSnake();
            ResetGame();
			GameTimer.Enabled = false;
			FoodMngr.AddRandomFood(20);
			FoodMngr.AddRandomFoodRed(10);
			FoodMngr.AddRandomFoodBlack(5);
			FoodMngr.AddRandomFoodYellow(5);
            FoodMngr.AddRandomObstacleDefault(10);
			FoodMngr.AddRandomPower(2);
            GameTimer.Interval = 25;
			GameCanvas.Invalidate();
		}

		private void ExtraBtn_Click(object sender, EventArgs e)
		{
            Player2.RemoveSnake();
            ResetGame();
			GameTimer.Enabled = false;
			FoodMngr.AddRandomFood(20);
			FoodMngr.AddRandomFoodRed(10);
			FoodMngr.AddRandomFoodBlack(5);
			FoodMngr.AddRandomFoodYellow(5);
			GameTimer.Interval = 100;
			GameCanvas.Invalidate();
		}

		private void TimerBtn_Click(object sender, EventArgs e)
		{
            Player2.RemoveSnake();
            ResetGame();
			GameTimer.Interval = 100;
			TimerMode.Start();
			TimerMode.Enabled = true;
			GameTimer.Enabled = false;
			FoodMngr.AddRandomFood(15);
			FoodMngr.AddRandomFoodRed(5);
			FoodMngr.AddRandomFoodBlack(5);
			FoodMngr.AddRandomFoodYellow(5);
			FoodMngr.AddRandomPower(2);
			GameCanvas.Invalidate();
		}

		private void btn2PMode_Click(object sender, EventArgs e)
		{
			_2PGameReset();
			GameTimer.Enabled = false;
			FoodMngr.AddRandomFood(20);
			FoodMngr.AddRandomFoodRed(10);
			FoodMngr.AddRandomFoodBlack(5);
			FoodMngr.AddRandomFoodYellow(5);
            FoodMngr.AddRandomObstacleDefault(10);
			FoodMngr.AddRandomPower(2);
            GameTimer.Interval = 25;
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
				case 4:
					this.btnChange.Click += new System.EventHandler(this.ExtraBtn_Click);
					break;
				case 5:
					this.btnChange.Click += new System.EventHandler(this.btn2PMode_Click);
					break;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
        }

        private void txtHighScore_TextChanged(object sender, EventArgs e)
        {
            String path = Directory.GetCurrentDirectory();
            string realfile = path + "/score.txt";
            string sprt = Environment.NewLine;

            var hscore = File.ReadAllLines(realfile);
            string output = string.Join(sprt, hscore);
            string output2 = "Highscore     Name" + Environment.NewLine + output;
            txtHighScore.Text = output2;
        }
    }
}
