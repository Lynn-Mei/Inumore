using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxentold.Links
{
    public static class SpriteBatchManager
    {
        private static SpriteBatch spriteBatch;
        private static SpriteFont defaultFont;

        public static SpriteFont DefaultFont { get { return defaultFont; } }
        public static SpriteBatch SpriteBatch { get { return spriteBatch; } }
        
        public static void Initialize(SpriteBatch batch, SpriteFont font)
        {
            spriteBatch = batch;
            defaultFont = font;
        }

        public static void Begin()
        {
            spriteBatch.Begin();
        }

        public static void End()
        {
            spriteBatch.End();
        }

    }

}
