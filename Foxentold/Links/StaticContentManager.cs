using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxentold.Links
{
    /// <summary>
    /// Manager in charge of the static content loader
    /// </summary>
    public static class StaticContentManager
    {
        private static ContentManager content;

        /// <summary>
        /// Initializes the content manager
        /// </summary>
        /// <param name="contentManager"></param>
        public static void Initialize(ContentManager contentManager)
        {
            content = contentManager;
        }

        /// <summary>
        /// Loads a content
        /// </summary>
        /// <typeparam name="T">Content type</typeparam>
        /// <param name="assetName">Content's name</param>
        /// <returns>Loaded content</returns>
        public static T Load<T>(string assetName)
        {
            return content.Load<T>(assetName);
        }
    }
}
