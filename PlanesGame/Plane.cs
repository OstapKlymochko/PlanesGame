using Timer = System.Windows.Forms.Timer;

namespace PlanesGame
{
	public abstract class Plane: PictureBox
	{	
		public abstract void move(object sender, EventArgs e);
		public void shoot(object sender, PlaneShootArgs e)
		{
			Form f = sender as Form;
			Missile missile1 = new Missile(e.Location);
			Missile missile2 = new Missile(new Point(e.Location.X + this.Width - 15, e.Location.Y));
			f.Controls.Add(missile1);
			f.Controls.Add(missile2);
			Timer missileOut = new Timer();
			missileOut.Interval = 10;
			MissileEventArgs dir = new MissileEventArgs() { Direction = e.Direction, FHeight = f.Height, timer = missileOut };
			missileOut.Tick += (sender, e) => missile1.move(this, dir);
			missileOut.Tick += (sender, e) => missile2.move(this, dir);
			missileOut.Start();
		}
	}
	public class PlaneShootArgs : EventArgs
	{
		public Directions Direction { get; init; }
		public Point Location { get; init; }

	}
}
