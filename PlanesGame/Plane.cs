using Timer = System.Windows.Forms.Timer;

namespace PlanesGame
{
	public abstract class Plane: PictureBox
	{	
		public abstract void move(object sender, EventArgs e);
		//public static List<Timer> missileOutTimers;
		public void shoot(object sender, PlaneShootArgs e)
		{
			GameForm f = sender as GameForm;
			Missile missile1 = new Missile(new Point(e.Location.X + 10, e.Location.Y));
			Missile missile2 = new Missile(new Point(e.Location.X + this.Width - 20, e.Location.Y));
			if(e.Direction == Directions.down)
			{
				missile1.BackColor = Color.Red;
				missile2.BackColor = Color.Red;
			}
			f.Controls.Add(missile1);
			f.Controls.Add(missile2);
			Timer missileOut = new Timer();
			missileOut.Interval = 20;

			MissileEventArgs dir = new MissileEventArgs() { Direction = e.Direction, timer = missileOut};
			missileOut.Tick += (sender, e) => missile1.move(f, dir);
			missileOut.Tick += (sender, e) => missile2.move(f, dir);
			GameForm.missileOutTimers.Add(missileOut);
			missileOut.Start();
		}
	}
	public class PlaneShootArgs : EventArgs
	{
		public Directions Direction { get; init; }
		public Point Location { get; init; }
	}
}
