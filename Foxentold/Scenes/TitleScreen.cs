using Foxentold.Animations;
using Foxentold.Drawables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxentold.Scenes
{
    public class TitleScreen:Scene
    {
        
        public TitleScreen(int x, int y) : base(x, y)
        {
            LargeSprite inu = new LargeSprite(this, 100, 100, "images/inu");
            inu.CenterXAxis();
            this.drawable.Add(inu);

            LargeSprite logo = new LargeSprite(this, -900, 150, "images/logo");
            //logo.CenterXAxis();
            //this.drawable.Add(logo);

            LargeSprite subtitle = new LargeSprite(this, 100, 250, "images/koroneraiser");
            subtitle.SetXtoCenter();
            this.drawable.Add(subtitle);
            //this.drawable.Add(new DisplayedText(this, 50, 50, "Hello World"));
            TitleSlideAnimation title = new TitleSlideAnimation();
            List<GameItem> items = new List<GameItem>();
            items.Add(logo);
            title.setFrames(items);
            title.Play();
            this.animations.Add(title);

        }

        protected override void AbstractedUpdate()
        {
            /*
            if (!this.animations[0].IsPlaying && this.animations[0].TimesPlayed > this.animations[1].TimesPlayed)
            {
                this.animations[1].Play();
            }
            if(!this.animations[1].IsPlaying && this.animations[1].TimesPlayed > this.animations[2].TimesPlayed)
            {
                this.animations[2].Play();
            }*/
        }

        public void Settings()
        {

        }

        public void Play()
        {

        }

        public void PlayAnimation()
        {

        }

    }
}
