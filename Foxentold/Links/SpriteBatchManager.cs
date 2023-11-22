using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxentold.Links
{
    /// <summary>
    /// A class in charge of managing the spritebatch
    /// </summary>
    public static class SpriteBatchManager
    {
        private static SpriteBatch spriteBatch;
        private static SpriteFont defaultFont;

        /// <summary>
        /// Getter for the default font
        /// </summary>
        public static SpriteFont DefaultFont { get { return defaultFont; } }

        /// <summary>
        /// Getter for the spritebatch
        /// </summary>
        public static SpriteBatch SpriteBatch { get { return spriteBatch; } }
        
        /// <summary>
        /// Initializrs the spritebatch and the game's default font
        /// </summary>
        /// <param name="batch"></param>
        /// <param name="font"></param>
        public static void Initialize(SpriteBatch batch, SpriteFont font)
        {
            spriteBatch = batch;
            defaultFont = font;
        }

        /// <summary>
        /// Begins the sprite batch
        /// </summary>
        public static void Begin()
        {
            spriteBatch.Begin();
        }

        /// <summary>
        /// Ends the sprite batch
        /// </summary>
        public static void End()
        {
            spriteBatch.End();
        }

    }

}
