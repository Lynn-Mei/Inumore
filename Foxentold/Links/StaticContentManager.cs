using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxentold.Links
{
    public static class StaticContentManager
    {
        private static ContentManager content;
        public static void Initialize(ContentManager contentManager)
        {
            content = contentManager;
        }
        public static T Load<T>(string assetName)
        {
            return content.Load<T>(assetName);
        }
    }
}
