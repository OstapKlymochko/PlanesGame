using Timer = System.Windows.Forms.Timer;

namespace PlanesGame
{
	public abstract class Plane: PictureBox
	{	
		public abstract void move(object sender, EventArgs e);
		public void shoot(object sender, PlaneShootArgs e)
		{
			Form1 f = sender as Form1;
			Missile missile1 = new Missile(new Point(e.Location.X + 10, e.Location.Y));
			Missile missile2 = new Missile(new Point(e.Location.X + this.Width - 20, e.Location.Y));
			f.Controls.Add(missile1);
			f.Controls.Add(missile2);
			Timer missileOut = new Timer();
			missileOut.Interval = 10;
			MissileEventArgs dir = new MissileEventArgs() { Direction = e.Direction, timer = missileOut};
			missileOut.Tick += (sender, e) => missile1.move(f, dir);
			missileOut.Tick += (sender, e) => missile2.move(f, dir);
			missileOut.Start();
		}
	}
	public class PlaneShootArgs : EventArgs
	{
		public Directions Direction { get; init; }
		public Point Location { get; init; }
	}
}
