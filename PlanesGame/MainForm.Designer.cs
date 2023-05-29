namespace PlanesGame
{
	partial class MainForm
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
			SideBar = new Panel();
			Exit = new Button();
			NavToGame = new Button();
			Content = new Panel();
			SubmitUserName = new Button();
			Username = new Label();
			UserNameInput = new TextBox();
			folderBrowserDialog1 = new FolderBrowserDialog();
			Record = new Label();
			SideBar.SuspendLayout();
			Content.SuspendLayout();
			SuspendLayout();
			// 
			// SideBar
			// 
			SideBar.Controls.Add(Exit);
			SideBar.Controls.Add(NavToGame);
			SideBar.Dock = DockStyle.Left;
			SideBar.Location = new Point(0, 0);
			SideBar.Name = "SideBar";
			SideBar.Size = new Size(219, 570);
			SideBar.TabIndex = 0;
			// 
			// Exit
			// 
			Exit.Location = new Point(12, 531);
			Exit.Name = "Exit";
			Exit.Size = new Size(97, 27);
			Exit.TabIndex = 1;
			Exit.Text = "Завершити";
			Exit.UseVisualStyleBackColor = true;
			Exit.Click += button1_Click;
			// 
			// NavToGame
			// 
			NavToGame.Enabled = false;
			NavToGame.Location = new Point(0, 12);
			NavToGame.Name = "NavToGame";
			NavToGame.Size = new Size(213, 46);
			NavToGame.TabIndex = 0;
			NavToGame.Text = "Гра";
			NavToGame.UseVisualStyleBackColor = true;
			NavToGame.Click += NavToGame_Click;
			// 
			// Content
			// 
			Content.Controls.Add(Record);
			Content.Controls.Add(SubmitUserName);
			Content.Controls.Add(Username);
			Content.Controls.Add(UserNameInput);
			Content.Dock = DockStyle.Fill;
			Content.Location = new Point(219, 0);
			Content.Name = "Content";
			Content.Size = new Size(774, 570);
			Content.TabIndex = 1;
			// 
			// SubmitUserName
			// 
			SubmitUserName.Location = new Point(254, 70);
			SubmitUserName.Name = "SubmitUserName";
			SubmitUserName.Size = new Size(105, 23);
			SubmitUserName.TabIndex = 2;
			SubmitUserName.Text = "Авторизувати";
			SubmitUserName.UseVisualStyleBackColor = true;
			SubmitUserName.Click += SubmitUserName_Click;
			// 
			// Username
			// 
			Username.AutoSize = true;
			Username.Location = new Point(16, 43);
			Username.Name = "Username";
			Username.Size = new Size(100, 15);
			Username.TabIndex = 1;
			Username.Text = "Ім'я користувача";
			// 
			// UserNameInput
			// 
			UserNameInput.Location = new Point(16, 70);
			UserNameInput.Name = "UserNameInput";
			UserNameInput.Size = new Size(211, 23);
			UserNameInput.TabIndex = 0;
			// 
			// Record
			// 
			Record.AutoSize = true;
			Record.Location = new Point(16, 126);
			Record.Name = "Record";
			Record.Size = new Size(79, 15);
			Record.TabIndex = 3;
			Record.Text = "Ваш рекорд: ";
			Record.Visible = false;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(993, 570);
			Controls.Add(Content);
			Controls.Add(SideBar);
			Name = "MainForm";
			Text = "Літачки";
			Load += MainForm_Load;
			SideBar.ResumeLayout(false);
			Content.ResumeLayout(false);
			Content.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		public Panel SideBar;
		public Panel Content;
		private Button NavToGame;
		private Button Exit;
		private FolderBrowserDialog folderBrowserDialog1;
		private TextBox UserNameInput;
		private Label Username;
		private Button SubmitUserName;
		private Label Record;
	}
}