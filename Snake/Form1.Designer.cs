namespace Snake
{
	partial class SnakeForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}


		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SnakeForm));
            this.GameCanvas = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.TimerMode = new System.Windows.Forms.Timer(this.components);
            this.TimeCount = new System.Windows.Forms.Timer(this.components);
            this.Start_Btn = new System.Windows.Forms.Button();
            this.DareBtn = new System.Windows.Forms.Button();
            this.DropDown = new System.Windows.Forms.ComboBox();
            this.lblGameMode = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.ScoreTxtBox = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.ScoreLbl = new System.Windows.Forms.Label();
            this.txtHighScore = new System.Windows.Forms.TextBox();
            this.lblHighScore = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.GameCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // GameCanvas
            // 
            this.GameCanvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(196)))), ((int)(((byte)(222)))));
            this.GameCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameCanvas.Location = new System.Drawing.Point(4, 3);
            this.GameCanvas.Name = "GameCanvas";
            this.GameCanvas.Size = new System.Drawing.Size(950, 600);
            this.GameCanvas.TabIndex = 0;
            this.GameCanvas.TabStop = false;
            this.GameCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.GameCanvas_Paint);
            // 
            // GameTimer
            // 
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // TimerMode
            // 
            this.TimerMode.Tick += new System.EventHandler(this.TimerMode_Tick);
            // 
            // TimeCount
            // 
            this.TimeCount.Tick += new System.EventHandler(this.TimeCount_Tick);
            // 
            // Start_Btn
            // 
            this.Start_Btn.Location = new System.Drawing.Point(977, 12);
            this.Start_Btn.Name = "Start_Btn";
            this.Start_Btn.Size = new System.Drawing.Size(184, 23);
            this.Start_Btn.TabIndex = 1;
            this.Start_Btn.Text = "Start/Pause";
            this.Start_Btn.UseVisualStyleBackColor = true;
            this.Start_Btn.Click += new System.EventHandler(this.Start_Btn_Click);
            // 
            // DareBtn
            // 
            this.DareBtn.Location = new System.Drawing.Point(977, 540);
            this.DareBtn.Name = "DareBtn";
            this.DareBtn.Size = new System.Drawing.Size(184, 23);
            this.DareBtn.TabIndex = 2;
            this.DareBtn.TabStop = false;
            this.DareBtn.Text = "I Dare You To Press Me";
            this.DareBtn.UseVisualStyleBackColor = true;
            this.DareBtn.Click += new System.EventHandler(this.DareBtn_Click);
            // 
            // DropDown
            // 
            this.DropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropDown.IntegralHeight = false;
            this.DropDown.Items.AddRange(new object[] {
            "Easy",
            "Hard",
            "Impossible",
            "Timer",
			"Reverse"});
            this.DropDown.Location = new System.Drawing.Point(977, 142);
            this.DropDown.MaxDropDownItems = 5;
            this.DropDown.Name = "DropDown";
            this.DropDown.Size = new System.Drawing.Size(185, 21);
            this.DropDown.TabIndex = 0;
            this.DropDown.SelectedIndexChanged += new System.EventHandler(this.DropDown_SelectedIndexChanged);
            // 
            // lblGameMode
            // 
            this.lblGameMode.AutoSize = true;
            this.lblGameMode.Location = new System.Drawing.Point(977, 126);
            this.lblGameMode.Name = "lblGameMode";
            this.lblGameMode.Size = new System.Drawing.Size(68, 13);
            this.lblGameMode.TabIndex = 5;
            this.lblGameMode.Text = "Game Mode:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(977, 569);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(44, 13);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "Time (s)";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(977, 169);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(184, 23);
            this.btnChange.TabIndex = 1;
            this.btnChange.Text = "Change Mode";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // ScoreTxtBox
            // 
            this.ScoreTxtBox.Enabled = false;
            this.ScoreTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.ScoreTxtBox.Location = new System.Drawing.Point(1000, 67);
            this.ScoreTxtBox.Name = "ScoreTxtBox";
            this.ScoreTxtBox.ReadOnly = true;
            this.ScoreTxtBox.Size = new System.Drawing.Size(140, 44);
            this.ScoreTxtBox.TabIndex = 3;
            // 
            // txtTime
            // 
            this.txtTime.Enabled = false;
            this.txtTime.Location = new System.Drawing.Point(1021, 569);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(140, 20);
            this.txtTime.TabIndex = 3;
            // 
            // ScoreLbl
            // 
            this.ScoreLbl.AutoSize = true;
            this.ScoreLbl.Location = new System.Drawing.Point(977, 51);
            this.ScoreLbl.Name = "ScoreLbl";
            this.ScoreLbl.Size = new System.Drawing.Size(38, 13);
            this.ScoreLbl.TabIndex = 4;
            this.ScoreLbl.Text = "Score:";
            // 
            // txtHighScore
            // 
            this.txtHighScore.Enabled = false;
            this.txtHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtHighScore.Location = new System.Drawing.Point(980, 211);
            this.txtHighScore.Multiline = true;
            this.txtHighScore.Name = "txtHighScore";
            this.txtHighScore.ReadOnly = true;
            this.txtHighScore.Size = new System.Drawing.Size(182, 239);
            this.txtHighScore.TabIndex = 3;
            this.txtHighScore.TextChanged += new System.EventHandler(this.txtHighScore_TextChanged);
            // 
            // lblHighScore
            // 
            this.lblHighScore.AutoSize = true;
            this.lblHighScore.Location = new System.Drawing.Point(977, 195);
            this.lblHighScore.Name = "lblHighScore";
            this.lblHighScore.Size = new System.Drawing.Size(60, 13);
            this.lblHighScore.TabIndex = 4;
            this.lblHighScore.Text = "HighScore:";
            // 
            // listView1
            // 
            this.listView1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("listView1.BackgroundImage")));
            this.listView1.Location = new System.Drawing.Point(980, 456);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(181, 78);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // SnakeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 609);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.ScoreLbl);
            this.Controls.Add(this.ScoreTxtBox);
            this.Controls.Add(this.txtHighScore);
            this.Controls.Add(this.lblHighScore);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.DareBtn);
            this.Controls.Add(this.Start_Btn);
            this.Controls.Add(this.DropDown);
            this.Controls.Add(this.lblGameMode);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.GameCanvas);
            this.Name = "SnakeForm";
            this.Text = "Snake";
            ((System.ComponentModel.ISupportInitialize)(this.GameCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}


		#endregion

		private System.Windows.Forms.PictureBox GameCanvas;
		private System.Windows.Forms.Timer GameTimer;
		private System.Windows.Forms.Timer TimerMode;
		private System.Windows.Forms.Timer TimeCount;
		private System.Windows.Forms.Button Start_Btn;
		private System.Windows.Forms.Button DareBtn;
		//private System.Windows.Forms.Button EasyBtn;
		//private System.Windows.Forms.Button HardBtn;
		//private System.Windows.Forms.Button TimerBtn;
		//private System.Windows.Forms.Button ImpossibleBtn;
		private System.Windows.Forms.ComboBox DropDown;
		private System.Windows.Forms.Button btnChange;
		private System.Windows.Forms.TextBox ScoreTxtBox, txtHighScore,txtTime;
		private System.Windows.Forms.Label ScoreLbl, lblGameMode, lblHighScore,lblTime;
        private System.Windows.Forms.ListView listView1;
    }
}

