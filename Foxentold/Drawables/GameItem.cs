using Foxentold.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxentold.Drawables
{
    public abstract class GameItem:IDrawable
    {
        protected Scene parent;
        protected int x=0;
        protected int y=0;
        protected int relativeX = 0;
        protected int relativeY = 0;
        public GameItem(Scene parent, int x, int y)
        {
            this.parent = parent;
            this.x = x;
            this.y = y;
            this.updateRelativePos();
        }

        public abstract int DrawOrder { get; }

        public abstract bool Visible { get; }

        public abstract event EventHandler<EventArgs> DrawOrderChanged;
        public abstract event EventHandler<EventArgs> VisibleChanged;

        public abstract void Draw(GameTime gameTime);

        public void applyVector(Vector2 vector)
        {
            Vector2 current = new Vector2(x, y);
            current += vector;
            this.x = (int)current.X;
            this.y = (int)current.Y;
            this.updateRelativePos();
        }

        public Vector2 Position
        {
            get
            {
                return new Vector2(x, y);
            }

            set
            {
                this.x = Convert.ToInt32(value.X);
                this.y = Convert.ToInt32(value.Y);
            }
        }

        public void updateRelativePos()
        {
            this.relativeX = this.parent.Coordinates.Item1 + this.x;
            this.relativeY = this.parent.Coordinates.Item2 + this.y;
        }

    }
}
