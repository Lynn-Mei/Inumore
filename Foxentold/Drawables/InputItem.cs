using Foxentold.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxentold.Drawables
{
    public abstract class InputItem : GameItem
    {
        protected InputItem(Scene parent, int x, int y) : base(parent, x, y)
        {

        }

        public override bool Focus { get { return this.focus; } }

        public abstract void ManageInputs();

        public void switchFocus()
        {
            focus = !focus;
        }
    }
}
