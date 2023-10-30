using Foxentold.Drawables;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxentold.Animations
{
    public class TitleSlideAnimation : Animation
    {
        public TitleSlideAnimation(short version):base(version)
        {
        }
        public void setFrames(List<GameItem> frames)
        {
            foreach(GameItem frame in frames)
            {
                this.AddFrame(frame);
            }
        }
        protected override void DefineAnimation()
        {
            this.speed = 10;
            if (this.version == 0) { }
            else if (this.version == 1)
            {
                this.movement.Add(new Microsoft.Xna.Framework.Vector2(200, 150));
            }
            else if(this.version == 2)
            {
                this.movement.Add(new Microsoft.Xna.Framework.Vector2(650, 250));
            }
            else
            {
                this.speed = 15;
                int centerX = 300; // X-coordinate of the circle's center
                int centerY = 300; // Y-coordinate of the circle's center
                const int radius = 300; // Radius of the circle
                
                List<(double, double)> coo = new List<(double, double)>();
                //first circle
                for (int i = 180; i <= 360; i += 5)
                {
                    int x = (int)(centerX + radius * Math.Cos(2 * 3.14 * i / 360));
                    int y = (int)(centerY + radius * Math.Sin(2 * 3.14 * i / 360));
                    coo.Add((x, y));
                    this.movement.Add(new Vector2((int)x, (int)y));
                }
                const int newRadius = 200;
                centerX = (int)this.movement[this.movement.Count-1].X - (-1 * (newRadius - radius));
                for (int i = 90; i <= 270; i += 5)
                {
                    int x = (int)(centerX + newRadius * Math.Cos(2 * 3.14 * i / 360));
                    int y = (int)(centerY + newRadius * Math.Sin(2 * 3.14 * i / 360));
                    coo.Add((x, y));
                    this.movement.Add(new Vector2((int)x, (int)y));
                }

                //this.movement.Add(new Microsoft.Xna.Framework.Vector2(500, 700));

            }
        }
    }
}
