using Timer = System.Windows.Forms.Timer;

namespace PlanesGame
{
	public partial class GameForm : Form
	{
		private int bgStarsSpeed = 4;
		private PictureBox[] bgStars;
		private Random random = new();
		Player player;
		public static List<Timer> missileOutTimers = new List<Timer>();
		public static List<Task> tasks = new List<Task>();
		private int points = 0;
		public int Points
		{
			get
			{
				return points;
			}
			set
			{
				points = value;
				this.Score.Text  = "Бали: " +points.ToString() + " " + EnemiesAppearance.Interval.ToString();
				if(points % 30 == 0)
				{
					this.EnemiesAppearance.Interval = EnemiesAppearance.Interval > 400 ? EnemiesAppearance.Interval - 100 : EnemiesAppearance.Interval;
				}
				if (points % 60 == 0) 
				{ 
					Enemy.movementSpeed += 2;
				}
			}
		}
		public GameForm()
		{
			InitializeComponent();
			player = new Player(this.Width / 2, this.Height - 200);
			this.Controls.Add(player);
			this.Score.Text = "Бали: " + points.ToString();
		}
		private void StartGameHandler()
		{
			while (this.Controls.ContainsKey("enemy"))
			{
				this.Controls.RemoveByKey("enemy");
			}
			GameForm.missileOutTimers.ForEach(t => t.Dispose());
			GameForm.missileOutTimers.Clear();
			this.EnemiesAppearance.Interval = 1500;
			Points = 0;
			Enemy.movementSpeed = 1;
			this.GameTimer.Start();
			this.KeyDown += this.Form1_KeyDown;
			this.EnemiesAppearance.Start();
			this.SideBar.Visible = false;
			this.player.Location = new Point(this.Width / 2, this.Height - 200);
			this.Focus();
		}
		public async void GameOver()
		{
			while (this.Controls.ContainsKey("missile"))
			{
				this.Controls.RemoveByKey("missile");
			}
			GameTimer.Stop();
			EnemiesAppearance.Stop();
			this.KeyDown -= this.Form1_KeyDown;
			this.SideBar.Visible = true;
			missileOutTimers.Clear();
			//this.SideBar.Focus();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			bgStars = new PictureBox[20];

			for (int i = 0; i < bgStars.Length; ++i)
			{
				bgStars[i] = new PictureBox();
				PictureBox star = bgStars[i];
				star.BorderStyle = BorderStyle.None;
				star.Location = new Point(random.Next(0, this.Width), random.Next(0, this.Height));
				if (i % 2 == 0)
				{
					star.Size = new Size(2, 2);
					star.BackColor = Color.Wheat;
				}
				else
				{
					star.Size = new Size(3, 3);
					star.BackColor = Color.Wheat;
				}
				this.Controls.Add(star);
			}
		}

		private void GameTimer_Tick(object sender, EventArgs e)
		{
			for (int i = 0; i < bgStars.Length; ++i)
			{
				PictureBox star = bgStars[i];
				star.Top += i % 2 == 0 ? this.bgStarsSpeed : this.bgStarsSpeed - 2;
				if (star.Top >= this.Height)
				{
					star.Top = -1;
				}
			}
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			this.player.move(this, e);
		}
		private async void EnemiesAppearance_Tick(object sender, EventArgs e)
		{
			Enemy enemy = new Enemy(random.Next(50, this.Width - 100));
			bool acceptableLocation = await Task.Run(() =>
			{
				Control[] enemies = this.Controls.Find("enemy", true);
				foreach (Control existingEnemy in enemies)
				{
					double distance = Program.DistanceBetweenTwoPoints(existingEnemy.Location, enemy.Location);
					if (distance < 100)
					{
						return false;
					}
				}
				return true;
			});
			if (acceptableLocation)
			{
				GameTimer.Tick += (sender, e) => enemy.move(this, e);
				this.Controls.Add(enemy);
			}
		}

		private void StartGame_Click(object sender, EventArgs e)
		{
			this.StartGameHandler();
		}
	}
}