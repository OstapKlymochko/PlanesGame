using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
		private bool isClose(Control c)
		{
			return c != null ? this.Location.Y >= c.Location.Y && this.Location.Y <= c.Location.Y + c.Height && (this.Location.X >= c.Location.X && this.Location.X <= c.Location.X + c.Width) : false;
		}
		private async void onMoveUp(GameForm f, MissileEventArgs args)
		{
			this.Top -= 10;
			var targetEnemies = await Task.Run(() =>
			{
				return f.Controls.Find("enemy", true).Where(e => this.isClose(e));
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
		private async void onMoveDown (GameForm f, MissileEventArgs args)
		{
			this.Top += Enemy.movementSpeed + 4;
			Control player = f.Controls["player"];
			if (this.isClose(player))
			{
				args.timer.Dispose();
				f.GameOver();
			}
		}
		public async void move(object sender, EventArgs e)
		{
			MissileEventArgs args = e as MissileEventArgs;
			GameForm f = sender as GameForm;
			if (args.Direction == Directions.up && this.Top >= 10)
			{
				this.onMoveUp(f, args);
			}
			else if (args.Direction == Directions.down && this.Bottom <= f.Height - 40)
			{
				this.onMoveDown(f, args);
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
