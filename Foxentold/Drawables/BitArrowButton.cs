using Foxentold.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxentold.Drawables
{
    public class BitArrowBtnGroup: GameItem
    {
        private List<BitArrowButton> bitArrowButtons = new List<BitArrowButton>();
        private int cursor;
        private bool focus = false;
        private int inXMargin = 0;
        private int lineHeight = 25;

        public override int DrawOrder => 1;

        public override bool Visible => true;

        public override event EventHandler<EventArgs> DrawOrderChanged;
        public override event EventHandler<EventArgs> VisibleChanged;
        public BitArrowBtnGroup(Scene parent, int x, int y, Dictionary<string, Action> options=null) : base(parent, x, y)
        {
            if(options != null) {
                int i = 0;
                foreach(string option in options.Keys)
                {
                    i++;
                    this.bitArrowButtons.Add(new BitArrowButton(parent, x+inXMargin, y+i*lineHeight, options[option], option));
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach(BitArrowButton btn in bitArrowButtons)
            {
                btn.Draw(gameTime);
            }
        }

        public void switchFocus()
        {
            this.focus = !focus;
        }

    }
    public class BitArrowButton: GameItem
    {
        private string text;
        private Action action;


        public override int DrawOrder => 2;

        public override bool Visible => true;

        public override event EventHandler<EventArgs> DrawOrderChanged;
        public override event EventHandler<EventArgs> VisibleChanged;

        public BitArrowButton(Scene parent, int x, int y, Action action, string text) : base(parent, x, y)
        {
            this.action = action;
            this.text = text;
        }

        public void Select()
        {
            this.action.Invoke();
        }
        public override void Draw(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
