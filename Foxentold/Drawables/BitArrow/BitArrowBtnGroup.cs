using Foxentold.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Color = Microsoft.Xna.Framework.Color;

namespace Foxentold.Drawables.BitArrow
{
    public class BitArrowBtnGroup : GameItem
    {
        private List<BitArrowButton> bitArrowButtons = new List<BitArrowButton>();
        private Dictionary<string, Action> options = new Dictionary<string, Action>();
        private int cursor = 0;
        private bool focus = false;
        private Color color = Color.Black;
        private int size;
        private int inXMargin = 0;
        private int lineHeight = 25;

        public override int DrawOrder => 1;

        public override bool Visible => true;

        public override event EventHandler<EventArgs> DrawOrderChanged;
        public override event EventHandler<EventArgs> VisibleChanged;
        public BitArrowBtnGroup(Scene parent, int x, int y, Dictionary<string, Action> options = null, 
            Color? color = null, int size = 15, int inXMargin = 0, int lineHeight = 25) : base(parent, x, y)
        {
            this.inXMargin = inXMargin;
            this.lineHeight = lineHeight;
            this.size = size;
            if (color != null)
                this.color = (Color)color;
            if (options != null)
                this.options = options;

            this.Initialize();
        }

        public void Initialize()
        {
            int i = 0;
            foreach (string option in options.Keys)
            {
                string optionText = option;
                if (i == cursor)
                    optionText = "> " + option;
                i++;
                DisplayedText text = new DisplayedText(parent, x + inXMargin, y + i * lineHeight, optionText, color, size);
                bitArrowButtons.Add(new BitArrowButton(parent, x + inXMargin, y + i * lineHeight, options[option], text));
            }
        }
        public override void Draw(GameTime gameTime)
        {
            foreach (BitArrowButton btn in bitArrowButtons)
            {
                btn.Draw(gameTime);
            }
        }

        public void switchFocus()
        {
            focus = !focus;
        }

    }
}
