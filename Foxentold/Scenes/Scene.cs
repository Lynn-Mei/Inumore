using Foxentold.Animations;
using Foxentold.Drawables;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxentold.Scenes
{
    /// <summary>
    /// Class defining mother class for scenes
    /// </summary>
    public abstract class Scene
    {
        protected int x;
        protected int y;
        protected Song bgm;
        protected List<GameItem> drawable = new List<GameItem>();
        protected List<GameItem> animatedDrawables = new List<GameItem>();
        protected List<Animation> animations = new List<Animation>();

        /// <summary>
        /// Getter for the coordinates of the scene
        /// </summary>
        public (int, int) Coordinates { get { return (x, y); } }

        /// <summary>
        /// Initializes the common attributes of scenes
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Scene(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Draws the scene's drawables and animated
        /// </summary>
        /// <param name="gameTime">the game time</param>
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

        /// <summary>
        /// Abstract method that adds a layer of update specific to a scene class
        /// </summary>
        /// <param name="gameTime">game's time</param>
        protected abstract void AbstractedUpdate(GameTime gameTime);

        /// <summary>
        /// Updates the scene
        /// </summary>
        /// <param name="gameTime"></param>
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
                    //if the animation is done stays on the last frame as a simple dwble
                    drawable.Add(animation.GetStopedFrame());
                }
            }
            //calls the abstract added update logic
            this.AbstractedUpdate(gameTime);
        }
    }
}
