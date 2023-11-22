using Foxentold.Links;
using Foxentold.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Foxentold.Drawables
{
    /// <summary>
    /// Gameitem representing large sprites
    /// </summary>
    public class LargeSprite : GameItem
    {
        private int drawOrder = 7;
        private bool visible = true;
        private Texture2D texture;

        public override int DrawOrder => drawOrder;

        public override bool Visible => visible;

        public override event EventHandler<EventArgs> DrawOrderChanged;
        public override event EventHandler<EventArgs> VisibleChanged;

        /// <summary>
        /// Initializrs a largeSprite game item
        /// </summary>
        /// <param name="parent">Reference to the parent of the sprite</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="ressourceName">Ressource name of the sprite</param>
        public LargeSprite(Scene parent, int x, int y, string ressourceName) : base(parent, x, y)
        {
            this.texture = StaticContentManager.Load<Texture2D>(ressourceName);
        }

        /// <summary>
        /// Draws the item based on relative position
        /// </summary>
        /// <param name="gameTime">game's time</param>
        public override void Draw(GameTime gameTime)
        {
            SpriteBatchManager.SpriteBatch.Draw(texture, new Vector2(this.relativeX, this.relativeY), Color.White);
        }
    }
}
