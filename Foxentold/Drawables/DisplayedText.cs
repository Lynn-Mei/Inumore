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
        private Color color;
        private int fontSize;

        public override int DrawOrder { get { return 14; } }

        public override bool Visible { get { return true; } }

        public override event EventHandler<EventArgs> DrawOrderChanged;
        public override event EventHandler<EventArgs> VisibleChanged;

        public DisplayedText(Scene parent,int x, int y,string text, Color? color=null, int size=15) :base(parent,x,y)
        {
            this.text = text;
            if(color == null) { 
                this.color = Color.Black;
            }
            else
            {
                this.color = (Color)color;
            }

            this.fontSize = size;
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteFont font = SpriteBatchManager.DefaultFont;
            Vector2 position = new Vector2(relativeX, relativeY);
            if (fontSize > 0)
            {
                float scale = fontSize / font.MeasureString(text).Y;
                //position.Y -= (font.MeasureString(text).Y - font.MeasureString(text * scale).Y) / 2;

                SpriteBatchManager.SpriteBatch.DrawString(font, text, position, color, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            }
            else //if size is below 0 the text is rendered at default font size
            {
                SpriteBatchManager.SpriteBatch.DrawString(font, this.text, position, color);
            }
                
        }


    }
}
