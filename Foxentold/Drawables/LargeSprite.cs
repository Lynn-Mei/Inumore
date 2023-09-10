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
    public class LargeSprite : GameItem, IDrawable
    {
        private int drawOrder = 7;
        private bool visible = true;
        private Texture2D texture;
        public LargeSprite(Scene parent, int x, int y, string ressourceName) : base(parent, x, y)
        {
            this.texture = StaticContentManager.Load<Texture2D>(ressourceName);
        }

        public override int DrawOrder => drawOrder;

        public override bool Visible => visible;

        public override event EventHandler<EventArgs> DrawOrderChanged;
        public override event EventHandler<EventArgs> VisibleChanged;

        public void CenterXAxis()
        {
            //Need to modify hardcoded game width
            //First get the total margin 
            int total_margin = 1280 - this.texture.Width;
            //then split the margin in two to center the image
            this.x = total_margin/2;
            this.updateRelativePos();
        }

        public void SetXtoCenter()
        {
            this.x = 1280 / 2;
            this.updateRelativePos();
        }

        public override void Draw(GameTime gameTime)
        {
            
            SpriteBatchManager.SpriteBatch.Draw(texture, new Vector2(this.relativeX, this.relativeY), Color.White);
        }
    }
}
