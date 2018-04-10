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
            this.Start_Btn = new System.Windows.Forms.Button();
            this.DareBtn = new System.Windows.Forms.Button();
            //this.EasyBtn = new System.Windows.Forms.Button();
            //this.HardBtn = new System.Windows.Forms.Button();
            //this.ImpossibleBtn = new System.Windows.Forms.Button();
            //this.TimerBtn = new System.Windows.Forms.Button();
			this.DropDown = new System.Windows.Forms.ComboBox();
			this.lblGameMode = new System.Windows.Forms.Label();
			this.btnChange = new System.Windows.Forms.Button();
            this.ScoreTxtBox = new System.Windows.Forms.TextBox();
            this.ScoreLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GameCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // GameCanvas
            // 
            this.GameCanvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GameCanvas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GameCanvas.BackgroundImage")));
            this.GameCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameCanvas.Location = new System.Drawing.Point(4, 3);
            this.GameCanvas.Name = "GameCanvas";
            this.GameCanvas.Size = new System.Drawing.Size(950, 643);
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
            // Start_Btn
            // 
            this.Start_Btn.Location = new System.Drawing.Point(977, 12);
            this.Start_Btn.Name = "Start_Btn";
            this.Start_Btn.Size = new System.Drawing.Size(205, 23);
            this.Start_Btn.TabIndex = 1;
            this.Start_Btn.Text = "Start/Pause";
            this.Start_Btn.UseVisualStyleBackColor = true;
            this.Start_Btn.Click += new System.EventHandler(this.Start_Btn_Click);
            // 
            // DareBtn
            // 
            this.DareBtn.Location = new System.Drawing.Point(976, 480);
            this.DareBtn.Name = "DareBtn";
            this.DareBtn.Size = new System.Drawing.Size(206, 23);
            this.DareBtn.TabIndex = 2;
            this.DareBtn.TabStop = false;
            this.DareBtn.Text = "I Dare You To Press Me";
            this.DareBtn.UseVisualStyleBackColor = true;
            this.DareBtn.Click += new System.EventHandler(this.DareBtn_Click);
			// 
			//DropDownList
			//
			string[] buttonName = new string[] { "Easy", "Hard", "Impossible", "Timer" };
			DropDown.Items.AddRange(buttonName);
			this.DropDown.Location = new System.Drawing.Point(977, 150);
			this.DropDown.IntegralHeight = false;
			this.DropDown.MaxDropDownItems = 5;
			this.DropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DropDown.Name = "cmbGameMode";
			this.DropDown.Size = new System.Drawing.Size(205, 25);
			this.DropDown.TabIndex = 0;
			this.Controls.Add(this.DropDown);
			//
			// lblGameMode
			//
			this.lblGameMode.AutoSize = true;
			this.lblGameMode.Location = new System.Drawing.Point(977, 134);
			this.lblGameMode.Name = "lblGameMode";
			this.lblGameMode.Size = new System.Drawing.Size(38, 13);
			this.lblGameMode.TabIndex = 5;
			this.lblGameMode.Text = "Game Mode:";
			//
			// btnChange
			//
			this.btnChange.Location = new System.Drawing.Point(977, 179);
			this.btnChange.Name = "btnChange";
			this.btnChange.Size = new System.Drawing.Size(205, 23);
			this.btnChange.TabIndex = 1;
			this.btnChange.Text = "Change Mode";
			this.btnChange.UseVisualStyleBackColor = true;
			if (this.DropDown.SelectedText == "Easy")
			{
				this.btnChange.Click += new System.EventHandler(this.EasyBtn_Click);
			}
			else if (this.DropDown.SelectedText == "Hard")
			{
				this.btnChange.Click += new System.EventHandler(this.HardBtn_Click);
			}
			else if (this.DropDown.SelectedText == "Impossible")
			{
			this.btnChange.Click += new System.EventHandler(this.ImpossibleBtn_Click);
			}
			else
				this.btnChange.Click += new System.EventHandler(this.TimerBtn_Click);
            // 
            // EasyBtn
            // 
            //this.EasyBtn.Location = new System.Drawing.Point(980, 83);
            //this.EasyBtn.Name = "EasyBtn";
            //this.EasyBtn.Size = new System.Drawing.Size(205, 23);
            //this.EasyBtn.TabIndex = 1;
            //this.EasyBtn.Text = "Go Easy";
            //this.EasyBtn.UseVisualStyleBackColor = true;
            //this.EasyBtn.Click += new System.EventHandler(this.EasyBtn_Click);
            // 
            // HardBtn
            // 
            //this.HardBtn.Location = new System.Drawing.Point(977, 285);
            //this.HardBtn.Name = "HardBtn";
            //this.HardBtn.Size = new System.Drawing.Size(205, 23);
            //this.HardBtn.TabIndex = 1;
            //this.HardBtn.Text = "Go Hard";
            //this.HardBtn.UseVisualStyleBackColor = true;
            //this.HardBtn.Click += new System.EventHandler(this.HardBtn_Click);
            // 
            // ImpossibleBtn
            // 
            //this.ImpossibleBtn.Location = new System.Drawing.Point(977, 394);
            //this.ImpossibleBtn.Name = "ImpossibleBtn";
            //this.ImpossibleBtn.Size = new System.Drawing.Size(205, 23);
            //this.ImpossibleBtn.TabIndex = 1;
            //this.ImpossibleBtn.Text = "Go Impossible";
            //this.ImpossibleBtn.UseVisualStyleBackColor = true;
            //this.ImpossibleBtn.Click += new System.EventHandler(this.ImpossibleBtn_Click);
            // 
            // TimerBtn
            // 
            //this.TimerBtn.Location = new System.Drawing.Point(977, 185);
            //this.TimerBtn.Name = "TimerBtn";
            //this.TimerBtn.Size = new System.Drawing.Size(205, 23);
            //this.TimerBtn.TabIndex = 1;
            //this.TimerBtn.Text = "Go with Time";
            //this.TimerBtn.UseVisualStyleBackColor = true;
            //this.TimerBtn.Click += new System.EventHandler(this.TimerBtn_Click);
            // 
            // ScoreTxtBox
            // 
            this.ScoreTxtBox.Enabled = false;
            this.ScoreTxtBox.Location = new System.Drawing.Point(1021, 48);
            this.ScoreTxtBox.Name = "ScoreTxtBox";
            this.ScoreTxtBox.ReadOnly = true;
            this.ScoreTxtBox.Size = new System.Drawing.Size(161, 20);
            this.ScoreTxtBox.TabIndex = 3;
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
            // SnakeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.ScoreLbl);
            this.Controls.Add(this.ScoreTxtBox);
            this.Controls.Add(this.DareBtn);
            this.Controls.Add(this.Start_Btn);
            //this.Controls.Add(this.EasyBtn);
            //this.Controls.Add(this.HardBtn);
            //this.Controls.Add(this.ImpossibleBtn);
            //this.Controls.Add(this.TimerBtn);
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
		private System.Windows.Forms.Button Start_Btn;
		private System.Windows.Forms.Button DareBtn;
		//private System.Windows.Forms.Button EasyBtn;
		//private System.Windows.Forms.Button HardBtn;
		//private System.Windows.Forms.Button TimerBtn;
		//private System.Windows.Forms.Button ImpossibleBtn;
		private System.Windows.Forms.ComboBox DropDown;
		private System.Windows.Forms.Button btnChange;
		private System.Windows.Forms.TextBox ScoreTxtBox;
		private System.Windows.Forms.Label ScoreLbl, lblGameMode;
	}
}

