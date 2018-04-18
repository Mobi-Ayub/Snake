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
            this.DropDown = new System.Windows.Forms.ComboBox();
            this.lblGameMode = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.ScoreTxtBox = new System.Windows.Forms.TextBox();
            this.ScoreLbl = new System.Windows.Forms.Label();
            this.txtHighScore = new System.Windows.Forms.TextBox();
            this.lblHighScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GameCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // GameCanvas
            // 
            this.GameCanvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GameCanvas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GameCanvas.BackgroundImage")));
            this.GameCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameCanvas.Location = new System.Drawing.Point(5, 4);
            this.GameCanvas.Margin = new System.Windows.Forms.Padding(4);
            this.GameCanvas.Name = "GameCanvas";
            this.GameCanvas.Size = new System.Drawing.Size(1266, 791);
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
            this.Start_Btn.Location = new System.Drawing.Point(1303, 15);
            this.Start_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Start_Btn.Name = "Start_Btn";
            this.Start_Btn.Size = new System.Drawing.Size(246, 28);
            this.Start_Btn.TabIndex = 1;
            this.Start_Btn.Text = "Start/Pause";
            this.Start_Btn.UseVisualStyleBackColor = true;
            this.Start_Btn.Click += new System.EventHandler(this.Start_Btn_Click);
            // 
            // DareBtn
            // 
            this.DareBtn.Location = new System.Drawing.Point(1301, 591);
            this.DareBtn.Margin = new System.Windows.Forms.Padding(4);
            this.DareBtn.Name = "DareBtn";
            this.DareBtn.Size = new System.Drawing.Size(246, 28);
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
            "Timer"});
            this.DropDown.Location = new System.Drawing.Point(1303, 209);
            this.DropDown.Margin = new System.Windows.Forms.Padding(4);
            this.DropDown.MaxDropDownItems = 5;
            this.DropDown.Name = "DropDown";
            this.DropDown.Size = new System.Drawing.Size(245, 24);
            this.DropDown.TabIndex = 0;
            this.DropDown.SelectedIndexChanged += new System.EventHandler(this.DropDown_SelectedIndexChanged);
            // 
            // lblGameMode
            // 
            this.lblGameMode.AutoSize = true;
            this.lblGameMode.Location = new System.Drawing.Point(1303, 190);
            this.lblGameMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGameMode.Name = "lblGameMode";
            this.lblGameMode.Size = new System.Drawing.Size(89, 17);
            this.lblGameMode.TabIndex = 5;
            this.lblGameMode.Text = "Game Mode:";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(1303, 245);
            this.btnChange.Margin = new System.Windows.Forms.Padding(4);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(246, 28);
            this.btnChange.TabIndex = 1;
            this.btnChange.Text = "Change Mode";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // ScoreTxtBox
            // 
            this.ScoreTxtBox.Enabled = false;
            this.ScoreTxtBox.Location = new System.Drawing.Point(1361, 59);
            this.ScoreTxtBox.Margin = new System.Windows.Forms.Padding(4);
            this.ScoreTxtBox.Name = "ScoreTxtBox";
            this.ScoreTxtBox.ReadOnly = true;
            this.ScoreTxtBox.Size = new System.Drawing.Size(186, 22);
            this.ScoreTxtBox.TabIndex = 3;
            // 
            // ScoreLbl
            // 
            this.ScoreLbl.AutoSize = true;
            this.ScoreLbl.Location = new System.Drawing.Point(1303, 63);
            this.ScoreLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ScoreLbl.Name = "ScoreLbl";
            this.ScoreLbl.Size = new System.Drawing.Size(49, 17);
            this.ScoreLbl.TabIndex = 4;
            this.ScoreLbl.Text = "Score:";
            // 
            // txtHighScore
            // 
            this.txtHighScore.Enabled = false;
            this.txtHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.txtHighScore.Location = new System.Drawing.Point(1333, 108);
            this.txtHighScore.Margin = new System.Windows.Forms.Padding(4);
            this.txtHighScore.Name = "txtHighScore";
            this.txtHighScore.ReadOnly = true;
            this.txtHighScore.Size = new System.Drawing.Size(186, 53);
            this.txtHighScore.TabIndex = 3;
            // 
            // lblHighScore
            // 
            this.lblHighScore.AutoSize = true;
            this.lblHighScore.Location = new System.Drawing.Point(1303, 89);
            this.lblHighScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHighScore.Name = "lblHighScore";
            this.lblHighScore.Size = new System.Drawing.Size(78, 17);
            this.lblHighScore.TabIndex = 4;
            this.lblHighScore.Text = "HighScore:";
            // 
            // SnakeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1621, 814);
            this.Controls.Add(this.ScoreLbl);
            this.Controls.Add(this.ScoreTxtBox);
            this.Controls.Add(this.txtHighScore);
            this.Controls.Add(this.lblHighScore);
            this.Controls.Add(this.DareBtn);
            this.Controls.Add(this.Start_Btn);
            this.Controls.Add(this.DropDown);
            this.Controls.Add(this.lblGameMode);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.GameCanvas);
            this.Margin = new System.Windows.Forms.Padding(4);
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
		private System.Windows.Forms.TextBox ScoreTxtBox, txtHighScore;
		private System.Windows.Forms.Label ScoreLbl, lblGameMode, lblHighScore;
	}
}

