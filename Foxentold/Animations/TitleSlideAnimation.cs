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
            this.movement.Add(new Microsoft.Xna.Framework.Vector2(200, 150));
        }
    }
}
