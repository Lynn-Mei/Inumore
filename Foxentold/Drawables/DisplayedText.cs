using Foxentold.Links;
using Foxentold.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using IDrawable = Microsoft.Xna.Framework.IDrawable;

namespace Foxentold.Drawables
{
    public class DisplayedText : GameItem
    {
        private string text;

        public override int DrawOrder { get { return 14; } }

        public override bool Visible { get { return true; } }

        public override event EventHandler<EventArgs> DrawOrderChanged;
        public override event EventHandler<EventArgs> VisibleChanged;

        public DisplayedText(Scene parent,int x, int y,string text) :base(parent,x,y)
        {
            this.text = text;

        }
        public override void Draw(GameTime gameTime)
        {
            SpriteFont font = SpriteBatchManager.DefaultFont;
            SpriteBatchManager.SpriteBatch.DrawString(font, this.text, new Vector2(relativeX, relativeY), Color.Black);
        }

    }
}
