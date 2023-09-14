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
            if (this.checkMovementEnd(currentPosition))
                this.movement.Remove(this.movement[0]);

            //Set new frame
            GameItem renderedFrame = this.setNewFrame();
            if (this.movement.Count > 0) {     
                //Get new Position according to vector
                Vector2 newPosition = this.getResultingVector(renderedFrame.Position, this.movement[0]);
                //Apply new position
                renderedFrame.applyVector(newPosition);
                this.currentPosition = renderedFrame.Position;
            }
            else
            {
                this.isPlaying = false;
            }
                
            return renderedFrame;
        }

        private GameItem setNewFrame()
        {
            //Get the frame
            GameItem newFrame = frames[currentFrame];
            //Set it's position to the animation's position
            newFrame.Position = this.currentPosition;
            //Set counter for the next iteration or reset if all frames are looped over
            currentFrame++;
            if (frames.Count == currentFrame)
                currentFrame = 0;
            
            return newFrame;
        }

        private Vector2 getResultingVector(Vector2 currentPosition, Vector2 movement)
        {
            Vector2 displacementVector = movement - currentPosition;

            // Calculate the length (magnitude) of the displacement vector
            float distance = displacementVector.Length();

            // Calculate the unit vector (normalized displacement vector)
            Vector2 unitVector = Vector2.Normalize(displacementVector);

            // Calculate the resulting vector for one second
            Vector2 resultingVector = unitVector * speed;

            //Avoiding going past the destination point (X)
            

            //Upper ceiling to avoid movement cancelation
            if(resultingVector.X > 0)
            {
                resultingVector.X = (float)Math.Ceiling(resultingVector.X);
            }
            else
            {
                resultingVector.X = (float)Math.Floor(resultingVector.X);
            }
            if (resultingVector.Y > 0)
            {
                resultingVector.Y = (float)Math.Ceiling(resultingVector.Y);
            }
            else
            {
                resultingVector.Y = (float)Math.Floor(resultingVector.Y);
            }
            int newX = (int)currentPosition.X + (int)resultingVector.X;
            int newY = (int)currentPosition.Y + (int)resultingVector.Y;

            int start = (int)currentPosition.X;
            int stop = (int)this.movement[0].X;
            if((int)currentPosition.X > this.movement[0].X)
            {
                stop = (int)currentPosition.X;
                start = (int)this.movement[0].X;
            }

            if (Enumerable.Range(start, stop).Contains(newX))
            {
                resultingVector.X = this.movement[0].X-currentPosition.X;
            }

            start = (int)currentPosition.Y;
            stop = (int)this.movement[0].Y;
            if ((int)currentPosition.Y > this.movement[0].Y)
            {
                stop = (int)currentPosition.Y;
                start = (int)this.movement[0].Y;
            }
            if (Enumerable.Range(start, stop).Contains(newY))
            {
                resultingVector.Y = this.movement[0].Y-currentPosition.Y;
            }

            return resultingVector;
        }

        private bool checkMovementEnd(Vector2 newPosition)
        {
            bool res = false;
            if (newPosition.X == this.movement[0].X && newPosition.Y == this.movement[0].Y)
                res = true;
            return res;
        }


    }
}
