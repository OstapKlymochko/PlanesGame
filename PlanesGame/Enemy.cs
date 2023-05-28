using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace PlanesGame
{
	class Enemy: Plane
	{
		Random random = new Random();
		public int ChanceToShoot { get; set; }
		public static int movementSpeed = 1;
		public Enemy(int x): base() 
		{
			ChanceToShoot = 2;
			this.Size = new Size(100, 100);
			this.BackColor = Color.Transparent;
			this.Image = Image.FromFile($@"..\..\..\images\E{random.Next(1, 4)}.png");
			this.Name = "enemy";
			this.Location = new Point(x, 0);
		}
		public override async void move(object sender, EventArgs e)
		{
			GameForm f = sender as GameForm;
			if(this.Bottom <= f.Height - 50)
			{
				this.Top += movementSpeed;
				bool isAbleToShoot = await Task.Run(() =>
				{
					if (f.Controls.Contains(this) && random.Next(0, 101) < 3)
					{
						return true;
					}
					return false;
				});
				if (isAbleToShoot)
				{
					this.shoot(f, new PlaneShootArgs() { Direction = Directions.down, Location = this.Location});
				}	
			}
			else
			{
				this.Dispose();
			}
		}
	}
	//class EnemieMoveArgs: EventArgs
	//{
 //       public int FHeight { get; init; }
 //   }
}
