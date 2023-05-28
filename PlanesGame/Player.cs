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
			Form f = sender as Form;
			KeyEventArgs key = e as KeyEventArgs;
			if (key.KeyCode == Keys.Left && this.Left >= 10)
			{
				this.Left -= 10;
			}
			if (key.KeyCode == Keys.Right && this.Right <= f.Width - 20)
			{
				this.Left += 10;
			}
			if (key.KeyCode == Keys.Down && this.Bottom <= f.Height - 40)
			{
				this.Top += 10;
			}
			if (key.KeyCode == Keys.Up && this.Top >= 10)
			{
				this.Top -= 10;
			}
			if (key.KeyCode == Keys.Space)
			{
				this.shoot(sender, new PlaneShootArgs() { Direction = Directions.up, Location = this.Location} );
			}
		}
		//public void shoot(object sender)
		//{
		//	Form f = sender as Form;
		//	Missile missile1 = new Missile(this.Location);
		//	Missile missile2 = new Missile(new Point(this.Location.X + this.Width - 15, this.Location.Y));
		//	f.Controls.Add(missile1);
		//	f.Controls.Add(missile2);
		//	Timer missileOut = new Timer();
		//	missileOut.Interval = 10;
		//	MissileEventArgs dir = new MissileEventArgs() {Direction = Directions.up, FHeight = f.Height, timer = missileOut };
		//	missileOut.Tick += (sender, e) => missile1.move(f, dir);
		//	missileOut.Tick += (sender, e) => missile2.move(f, dir);
		//	missileOut.Start();
		//}
	}
}
