using Foxentold.Links;
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
    public class BitArrowBtnGroup : InputItem
    {
        private List<BitArrowButton> bitArrowButtons = new List<BitArrowButton>();
        private Dictionary<string, Action> options = new Dictionary<string, Action>();
        private int cursor = 0;
        
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

            this.Update();
        }

        public void Update()
        {
            bitArrowButtons.Clear();
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

        public override void ManageInputs()
        {
            if (KeyboardInputReceiver.IsKeyNewPressed(Microsoft.Xna.Framework.Input.Keys.Down))
            {
                this.cursor++;
                if (cursor == options.Count)
                    this.cursor = 0;
                this.Update();
            }
                
            if (KeyboardInputReceiver.IsKeyNewPressed(Microsoft.Xna.Framework.Input.Keys.Up))
            {
                this.cursor--;
                if (cursor == -1)
                    this.cursor = options.Count-1;
                this.Update();
            }
            if (KeyboardInputReceiver.IsKeyNewPressed(Microsoft.Xna.Framework.Input.Keys.Enter))
            {
                this.execute();
            }    
        }

        private void execute()
        {
            int i = 0;
            foreach(BitArrowButton btn in bitArrowButtons)
            {
                if (i == this.cursor)
                    btn.Select();
                i++;
            }
        }

    }
}
