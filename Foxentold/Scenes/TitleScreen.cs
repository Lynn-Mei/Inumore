using Foxentold.Animations;
using Foxentold.Drawables;
using Foxentold.Links;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foxentold.Scenes
{
    public class TitleScreen:Scene
    {
        
        public TitleScreen(int x, int y) : base(x, y)
        {
            Song themeSong = StaticContentManager.Load<Song>("music/theme-song");
            MediaPlayer.Play(themeSong);

            this.drawable.Add(new DisplayedText(this, 500, 350, "* Yubi-Soft *", Color.White, 42));

            LargeSprite inu = new LargeSprite(this, 300, 500, "images/inu");

            LargeSprite logo = new LargeSprite(this, -900, 150, "images/logo");

            LargeSprite subtitle = new LargeSprite(this, 1500, 250, "images/koroneraiser");

            //subtitle.SetXtoCenter();
            //this.drawable.Add(subtitle);

            //this.drawable.Add(new DisplayedText(this, 50, 50, "Hello World"));
            TitleSlideAnimation slideAnimation2 = new TitleSlideAnimation(3);
            List<GameItem> items = new List<GameItem>();
            items.Add(inu);
            slideAnimation2.setFrames(items);
            this.animations.Add(slideAnimation2);

            TitleSlideAnimation title = new TitleSlideAnimation(1);
            items.Clear();
            items.Add(logo);
            title.setFrames(items);
            this.animations.Add(title);

            TitleSlideAnimation slideAnimation = new TitleSlideAnimation(2);
            items.Clear();
            items.Add(subtitle);
            slideAnimation.setFrames(items);
            this.animations.Add(slideAnimation);
            

        }

        protected override void AbstractedUpdate(GameTime gameTime)
        {
            if(gameTime.TotalGameTime >= TimeSpan.FromMilliseconds(3000) && this.animations[0].TimesPlayed == 0) { 
            
                this.ClearBoard();
                this.animations[0].Play();
            }
            if (!this.animations[0].IsPlaying && this.animations[0].TimesPlayed > this.animations[1].TimesPlayed)
            {
                this.animations[1].Play();
            }
            if(!this.animations[1].IsPlaying && this.animations[1].TimesPlayed > this.animations[2].TimesPlayed)
            {
                this.animations[2].Play();
            }
            
        }

        private void ClearBoard()
        {
            this.drawable = new List<GameItem>();
        }

        public void Settings()
        {

        }

        public override void Play()
        {
            
        }

        public void PlayAnimation()
        {

        }

    }
}
