namespace PlanesGame
{
	partial class Form1
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
			System.Windows.Forms.Timer EnemiesAppearance;
			GameTimer = new System.Windows.Forms.Timer(components);
			EnemiesAppearance = new System.Windows.Forms.Timer(components);
			SuspendLayout();
			// 
			// GameTimer
			// 
			GameTimer.Enabled = true;
			GameTimer.Interval = 50;
			GameTimer.Tick += GameTimer_Tick;
			// 
			// EnemiesAppearance
			// 
			EnemiesAppearance.Enabled = true;
			EnemiesAppearance.Interval = 1500;
			EnemiesAppearance.Tick += EnemiesAppearance_Tick;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(0, 0, 192);
			ClientSize = new Size(1176, 588);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			KeyDown += Form1_KeyDown;
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Timer GameTimer;
		private System.Windows.Forms.Timer EnemiesAppearance;
	}
}