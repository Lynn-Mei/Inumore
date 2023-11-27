using Foxentold.Animations;
using Foxentold.Drawables;
using Foxentold.Drawables.BitArrow;
using Foxentold.Links;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foxentold.Scenes
{
    /// <summary>
    /// Title Screen's scene
    /// </summary>
    public class TitleScreen:Scene
    {
        /// <summary>
        /// Initializes the Title sceen
        /// </summary>
        /// <param name="x">X coordinate of scene</param>
        /// <param name="y">Y coordinate of scene</param>
        public TitleScreen(int x, int y) : base(x, y)
        {
            this.bgm = StaticContentManager.Load<Song>("music/theme-song");
            this.playAnimation();
        }

        /// <summary>
        /// Initializes the animation of the title screen
        /// </summary>
        private void playAnimation()
        {
            //Play theme
            //MediaPlayer.Play(this.bgm);

            this.animations.Clear();
            this.drawable.Clear();
            this.drawable.Add(new DisplayedText(this, 500, 350, "* Yubi-Soft *", Color.White, 42));

            LargeSprite inu = new LargeSprite(this, 300, 500, "images/inu");
            LargeSprite logo = new LargeSprite(this, -900, 150, "images/logo");
            LargeSprite subtitle = new LargeSprite(this, 1500, 250, "images/koroneraiser");

            this.addToAnimations(3, inu);
            this.addToAnimations(1, logo);
            this.addToAnimations(2, subtitle);
            this.setReactions();
        }

        protected override void AbstractedUpdate(GameTime gameTime)
        {
            if(gameTime.TotalGameTime >= TimeSpan.FromMilliseconds(3000) && this.animations[0].TimesPlayed == 0) 
            { 
                this.drawable.Clear();
                this.animations[0].Play();
            }
            if (bgm.IsDisposed)
            {
                this.playAnimation();
            }
        }

        /// <summary>
        /// Creates a title slide animation from any item
        /// </summary>
        /// <param name="version">Title slide animation version</param>
        /// <param name="item">item used for the animation</param>
        private void addToAnimations(short version, GameItem item)
        {
            TitleSlideAnimation slideAnimation = new TitleSlideAnimation(version);
            List<GameItem> items = new List<GameItem>();
            items.Add(item);
            slideAnimation.setFrames(items);
            this.animations.Add(slideAnimation);
        }

        private void setReactions()
        {
            this.animations[0].Reaction = this.animations[1].Play;
            this.animations[1].Reaction = this.animations[2].Play;
            this.animations[2].Reaction = this.addButtons;
        }

        private void addButtons()
        {
            Dictionary<string, Action> actions = new Dictionary<string, Action>();
            actions["Play"] = this.Play;
            actions["Settings"] = this.Settings;
            BitArrowBtnGroup group = new BitArrowBtnGroup(this, 600, 450, actions, Color.White, 35, 0 ,50);
            group.switchFocus();
            this.drawable.Add(group);
        }

        /// <summary>
        /// Function called when Settings button is pressed
        /// </summary>
        public void Settings()
        {
            SceneFactory.CreateSettingsScreen(0, 0);
        }

        /// <summary>
        /// Function called when Play button is pressed
        /// </summary>
        public void Play()
        {
            
        }

    }
}
