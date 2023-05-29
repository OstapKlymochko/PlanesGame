

namespace PlanesGame
{
	public partial class MainForm : Form
	{
		List<UserData> users;
		public UserData currentUser;
		public MainForm()
		{
			InitializeComponent();
		}
		public void Reset()
		{
			this.UserNameInput.Text = string.Empty;
			this.SubmitUserName.Enabled = true;
			this.NavToGame.Enabled = false;
			this.Record.Text = "Ваш рекорд: ";
			this.Record.Visible = false;
		}
		private async void MainForm_Load(object sender, EventArgs e)
		{
			users = await Task.Run(() =>
			{
				return UserData.ReadUsersFromFile();
			});
		}
		private void NavToGame_Click(object sender, EventArgs e)
		{
			Program.Game.Show();
			this.Hide();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void SubmitUserName_Click(object sender, EventArgs e)
		{
			string username = this.UserNameInput.Text.Trim();
			if(string.IsNullOrEmpty(username))
			{
				MessageBox.Show("Обов'язкове Поле!");
				return;
			}
			var result = users.Select(u => u).Where(u => u.Username.ToLower().Trim() == username.ToLower()).FirstOrDefault();
			if(result == null) 
			{
				result = new UserData() { Username = username, Scores = new List<int>() };
				users.Add(result);
				UserData.WriteUsersToFile(users);
				users = UserData.ReadUsersFromFile();
				MessageBox.Show("Ви тепер зареєстровані! Вдалої Вам гри :)");
			}
			int max = result.Scores.Count() != 0 ? result.Scores.Max() : 0;
			this.Record.Text += " " + max.ToString();
			this.Record.Visible = true;
			currentUser = result;
			SubmitUserName.Enabled = false;
			NavToGame.Enabled = true;
		}
		public async void WriteToFileOnGameOver(object sender)
		{
			GameForm f = sender as GameForm;
			if (f != null)
			{
				users = UserData.ReadUsersFromFile();
				users.ForEach(u =>
				{
					if (u.Username.ToLower().Trim() == currentUser.Username.ToLower().Trim())
					{
						u.Scores.Add(f.Points);
					}
				});
			}
			UserData.WriteUsersToFile(users);
		}
	}
}
