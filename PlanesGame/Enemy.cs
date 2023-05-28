using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesGame
{
	class Enemy: Plane
	{
		Random random = new Random();
		public Enemy(int x): base() 
		{

			this.Size = new Size(100, 100);
			this.BackColor = Color.Transparent;
			this.Image = Image.FromFile($@"..\..\..\images\E{random.Next(1, 4)}.png");
			this.Name = "enemy";
			this.Location = new Point(x, 0);
		}
		public override void move(object sender, EventArgs e)
		{
			EnemieMoveArgs args = e as EnemieMoveArgs;
			if(this.Bottom <= args.FHeight - 50)
			{
				this.Top += 1;
			}
			else
			{
				this.Dispose();
			}
			if(random.Next(1,101) < 3)
			{
				this.shoot(sender, new PlaneShootArgs() { Direction = Directions.down, Location = this.Location } );
			}
		}
	}
	class EnemieMoveArgs: EventArgs
	{
        public int FHeight { get; init; }
    }
}
