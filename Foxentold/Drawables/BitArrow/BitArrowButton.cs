using Foxentold.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxentold.Drawables.BitArrow
{
    public class BitArrowButton : GameItem
    {
        private DisplayedText text;
        private Action action;


        public override int DrawOrder => 2;

        public override bool Visible => true;

        public override event EventHandler<EventArgs> DrawOrderChanged;
        public override event EventHandler<EventArgs> VisibleChanged;

        public BitArrowButton(Scene parent, int x, int y, Action action, DisplayedText text) : base(parent, x, y)
        {
            this.action = action;
            this.text = text;
        }

        public void Select()
        {
            action.Invoke();
        }
        public override void Draw(GameTime gameTime)
        {
            this.text.Draw(gameTime);
        }
    }
}
