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
            this.speed = 2;
            if (this.version == 1)
            {
                this.movement.Add(new Microsoft.Xna.Framework.Vector2(200, 150));
            }
            else if(this.version == 2)
            {
                this.movement.Add(new Microsoft.Xna.Framework.Vector2(650, 250));
            }
            else
            {
                this.speed = 10;
                int centerX = 600; // X-coordinate of the circle's center
                int centerY = 250; // Y-coordinate of the circle's center
                int radius = 200; // Radius of the circle

                List<(double, double)> coo = new List<(double, double)>();
                for (int i = 0; i <= 360; i++)
                {
                    int x = (int)(centerX + radius * Math.Cos(2*3.14*i/360));
                    int y = (int)(centerY + radius * Math.Sin(2*3.14*i/360));
                    coo.Add((x, y));
                    this.movement.Add(new Vector2((int)x, (int)y));
                }


                //this.movement.Add(new Microsoft.Xna.Framework.Vector2(500, 700));

            }
        }
    }
}
