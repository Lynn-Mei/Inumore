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
    /// <summary>
    /// Game item displaying text
    /// </summary>
    public class DisplayedText : GameItem
    {
        private string text;
        private Color color;
        private int fontSize;

        public override int DrawOrder { get { return 14; } }

        public override bool Visible { get { return true; } }

        public override event EventHandler<EventArgs> DrawOrderChanged;
        public override event EventHandler<EventArgs> VisibleChanged;

        /// <summary>
        /// Initializes the text game item
        /// </summary>
        /// <param name="parent">Reference to the parent scene</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="text">The text displayed</param>
        /// <param name="color">The color of the text</param>
        /// <param name="size">The font size</param>
        public DisplayedText(Scene parent,int x, int y,string text, Color? color=null, int size=15) :base(parent,x,y)
        {
            this.text = text;
            this.color = Color.Black;
            if (color != null) 
                this.color = (Color)color;

            this.fontSize = size;
        }

        /// <summary>
        /// Draws the text based on size and color
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            SpriteFont font = SpriteBatchManager.DefaultFont;
            Vector2 position = new Vector2(relativeX, relativeY);
            if (fontSize > 0)
            {
                float scale = fontSize / font.MeasureString(text).Y;
                SpriteBatchManager.SpriteBatch.DrawString(font, text, position, color, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            }
            else //if size is below 0 the text is rendered at default font size
            {
                SpriteBatchManager.SpriteBatch.DrawString(font, this.text, position, color);
            }
                
        }


    }
}
