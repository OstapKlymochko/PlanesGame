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
		}
		public void move(object sender, MissileEventArgs e)
		{
			if(e.Direction == Directions.up && this.Top >= 10)
			{
				this.Top -= 10;
			}
			else if (e.Direction == Directions.down && this.Bottom <= e.FHeight - 40)
			{
				this.Top += 10;
			}
			else
			{
				e.timer.Dispose();
				this.Dispose();
			}
		}

	}
		public class MissileEventArgs : EventArgs
		{
			public Directions Direction { get; init; }
			public int FHeight { get; init; }
			public Timer timer { get; init; }
		}
}
