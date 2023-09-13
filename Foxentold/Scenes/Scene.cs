using Foxentold.Animations;
using Foxentold.Drawables;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxentold.Scenes
{
    public abstract class Scene
    {
        protected int x;
        protected int y;
        protected List<GameItem> drawable = new List<GameItem>();
        protected List<GameItem> animatedDrawables = new List<GameItem>();
        protected List<Animation> animations = new List<Animation>();

        public (int, int) Coordinates { get { return (x, y); } }

        public Scene(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Draw(GameTime gameTime)
        {
            //Draw all drawables
            foreach (GameItem drawable in drawable)
            {
                drawable.Draw(gameTime);
            }
            foreach (GameItem drawable in animatedDrawables)
            {
                drawable.Draw(gameTime);
            }
        }

        protected abstract void AbstractedUpdate();

        public void Update(GameTime gameTime)
        {
            animatedDrawables.Clear();
            //Update the currently playing animations
            foreach(Animation animation in animations)
            {
                if (animation.IsPlaying)
                {
                    animatedDrawables.Add(animation.Update(gameTime));
                }
                else if (animation.TimesPlayed > 0)
                {
                    animatedDrawables.Add(animation.GetStopedFrame());
                }
            }
            this.AbstractedUpdate();
        }
    }
}
