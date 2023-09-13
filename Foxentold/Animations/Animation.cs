using Foxentold.Drawables;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxentold.Animations
{
    public abstract class Animation
    {
        private bool isPlaying = false;
        private short timesPlayed = 0;
        private int currentFrame = 0;
        private Vector2 currentPosition;
        protected short version;
        //pixel per seconds
        protected int speed=1;
        public bool IsPlaying { get => isPlaying; }
        public short TimesPlayed { get => timesPlayed; }

        private List<GameItem> frames = new List<GameItem>();
        protected List<Vector2> movement = new List<Vector2>();

        public Animation(short version)
        {
            this.version = version;
            this.DefineAnimation();
        }
        protected void AddFrame(GameItem frame)
        {
            this.frames.Add(frame);
        }
        protected abstract void DefineAnimation();
        public void Play()
        {
            this.currentPosition = this.frames[0].Position;
            this.isPlaying = true;
            this.timesPlayed++;
        }

        public GameItem GetStopedFrame()
        {
             GameItem renderedFrame = frames[currentFrame];
             renderedFrame.Position = currentPosition;
             return renderedFrame;
        }

        public GameItem Update(GameTime gametime)
        {

            //Set new frame
            GameItem renderedFrame = frames[currentFrame];
            renderedFrame.Position = this.currentPosition;
            if(frames.Count-1 == currentFrame)
            {
                currentFrame = 0;
            }
            else
            {
                currentFrame++;
            }

            //Get the amount of movement according to speed
            int momentum = Convert.ToInt32(gametime.ElapsedGameTime.TotalMilliseconds * 1000);

            Vector2 displacementVector = this.movement[0] - renderedFrame.Position;

            // Calculate the length (magnitude) of the displacement vector
            float distance = displacementVector.Length();

            // Calculate the unit vector (normalized displacement vector)
            Vector2 unitVector = Vector2.Normalize(displacementVector);

            // Calculate the resulting vector for one second
            Vector2 resultingVector = unitVector * speed;
            resultingVector.X = (float)Math.Ceiling(resultingVector.X);
            resultingVector.Y = (float)Math.Ceiling(resultingVector.Y);

            //Remove vector empty
            if (currentPosition.X == this.movement[0].X && currentPosition.Y == this.movement[0].Y)
            {
                //renderedFrame.Position = movement[0];
               // this.currentPosition = movement[0];
                this.movement.Remove(this.movement[0]);
                
            }
            else
            {
                renderedFrame.applyVector(resultingVector);
                Vector2 previousPos = currentPosition;
                this.currentPosition = renderedFrame.Position;
                if ((currentPosition.X > movement[0].X && previousPos.X < movement[0].X) ||
                    (currentPosition.X < movement[0].X && previousPos.X > movement[0].X))
                {
                    this.currentPosition.X = movement[0].X;
                }
                if ((currentPosition.Y > movement[0].Y && previousPos.Y < movement[0].Y) ||
                    (currentPosition.Y < movement[0].Y && previousPos.Y > movement[0].Y))
                {
                    this.currentPosition.X = movement[0].Y;
                }
            }
            
            
            
            //Apply result
            
            

            //Check if animation is done
            if (this.movement.Count <= 0)
                this.isPlaying = false;

            return renderedFrame;
        }


    }
}
