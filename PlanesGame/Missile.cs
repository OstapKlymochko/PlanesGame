using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace PlanesGame
{
	public enum Directions { up, down }
	public class Missile : PictureBox
	{
		public Missile(Point location)
		{
			this.Location = location;
			this.BorderStyle = BorderStyle.None;
			this.BackColor = Color.Wheat;
			this.Size = new Size(5, 5);
			this.Name = "missile";
		}
		public async void move(object sender, EventArgs e)
		{
			MissileEventArgs args = e as MissileEventArgs;
			GameForm f = sender as GameForm;
			if (args.Direction == Directions.up && this.Top >= 10)
			{
				this.Top -= 10;
				//var targetEnemies = f.Controls.Find("enemy", true).Where(e => Program.DistanceBetweenTwoPoints(e.Location, this.Location) < 100);
				var targetEnemies = await Task.Run(() =>
				{
					return f.Controls.Find("enemy", true).Where(e => Program.DistanceBetweenTwoPoints(e.Location, this.Location) < 100);
				});
				if (targetEnemies.Count() > 0)
				{
					targetEnemies.ToList().ForEach(e => {
						if (f.Controls.Contains(this))
						{
							f.Points += 10;
							e.Dispose();
						}
					});
					
					this.Dispose();
				}
			}
			else if (args.Direction == Directions.down && this.Bottom <= f.Height - 40)
			{
				this.Top += Enemy.movementSpeed + 4;
				Control player = f.Controls["player"];
				bool cond = player != null ? this.Location.Y >= player.Location.Y && this.Location.Y <= player.Location.Y + player.Height && (this.Location.X >= player.Location.X && this.Location.X <= player.Location.X + player.Width) : false;
				if (cond)
				{
					args.timer.Dispose();
					//player.Dispose();
					f.GameOver();
				}
			}
			else
			{
				args.timer.Dispose();
				this.Dispose();
			}
		}

	}
		public class MissileEventArgs : EventArgs
		{
			public Directions Direction { get; init; }
			public Timer timer { get; init; }
		}
}
