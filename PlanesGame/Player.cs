using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;


namespace PlanesGame
{
	class Player: Plane
	{
		public Player(int x, int y): base()
		{
			this.Size = new Size(100, 100);
			this.BackColor = Color.Transparent;
			this.Image = Image.FromFile(@"..\..\..\images\player.png");
			this.Name = "player";
			this.Location = new Point(x, y);
		}
		public override void move(object sender, EventArgs e)
		{
			GameForm f = sender as GameForm;
			KeyEventArgs key = e as KeyEventArgs;
			if (key.KeyCode == Keys.Left && this.Left >= 10)
			{
				this.Left -= 20;
			}
			if (key.KeyCode == Keys.Right && this.Right <= f.Width - 20)
			{
				this.Left += 20;
			}
			if (key.KeyCode == Keys.Down && this.Bottom <= f.Height - 40)
			{
				this.Top += 20;
			}
			if (key.KeyCode == Keys.Up && this.Top >= 10)
			{
				this.Top -= 20;
			}
			if (key.KeyCode == Keys.Space)
			{
				this.shoot(f, new PlaneShootArgs() { Direction = Directions.up, Location = this.Location} );
			}
			if (f.Controls.Find("enemy", true).Any(e => Program.DistanceBetweenTwoPoints(e.Location, this.Location) < 100))
			{
				f.GameOver();
			}
		}
	}
}
