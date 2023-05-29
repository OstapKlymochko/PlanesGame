namespace PlanesGame
{
	partial class GameForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			GameTimer = new System.Windows.Forms.Timer(components);
			SideBar = new Panel();
			Score = new Label();
			ToMainMenu = new Button();
			StartGame = new Button();
			EnemiesAppearance = new System.Windows.Forms.Timer(components);
			SideBar.SuspendLayout();
			SuspendLayout();
			// 
			// GameTimer
			// 
			GameTimer.Interval = 50;
			GameTimer.Tick += GameTimer_Tick;
			// 
			// SideBar
			// 
			SideBar.BackColor = SystemColors.Control;
			SideBar.Controls.Add(Score);
			SideBar.Controls.Add(ToMainMenu);
			SideBar.Controls.Add(StartGame);
			SideBar.Dock = DockStyle.Left;
			SideBar.Location = new Point(0, 0);
			SideBar.Name = "SideBar";
			SideBar.Size = new Size(225, 622);
			SideBar.TabIndex = 0;
			// 
			// Score
			// 
			Score.AutoSize = true;
			Score.Location = new Point(12, 126);
			Score.Name = "Score";
			Score.Size = new Size(46, 15);
			Score.TabIndex = 3;
			Score.Text = "Бали: 0";
			// 
			// ToMainMenu
			// 
			ToMainMenu.Location = new Point(12, 74);
			ToMainMenu.Name = "ToMainMenu";
			ToMainMenu.Size = new Size(146, 29);
			ToMainMenu.TabIndex = 2;
			ToMainMenu.Text = "До головного меню";
			ToMainMenu.UseVisualStyleBackColor = true;
			ToMainMenu.Click += ToMainMenu_Click;
			// 
			// StartGame
			// 
			StartGame.Location = new Point(12, 27);
			StartGame.Name = "StartGame";
			StartGame.Size = new Size(146, 26);
			StartGame.TabIndex = 0;
			StartGame.Text = "Почати Гру";
			StartGame.UseVisualStyleBackColor = true;
			StartGame.Click += StartGame_Click;
			// 
			// EnemiesAppearance
			// 
			EnemiesAppearance.Interval = 1500;
			EnemiesAppearance.Tick += EnemiesAppearance_Tick;
			// 
			// GameForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(0, 0, 192);
			ClientSize = new Size(1176, 622);
			Controls.Add(SideBar);
			Name = "GameForm";
			Text = "Літачки";
			Load += Form1_Load;
			KeyDown += Form1_KeyDown;
			SideBar.ResumeLayout(false);
			SideBar.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Timer GameTimer;
		private Panel SideBar;
		private Button StartGame;
		private Button ToMainMenu;
		private Label Score;
		private System.Windows.Forms.Timer EnemiesAppearance;
	}
}