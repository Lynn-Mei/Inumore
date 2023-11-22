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

        /// <summary>
        /// Initializes the animation
        /// </summary>
        /// <param name="version">the version id of the animation</param>
        public Animation(short version)
        {
            this.version = version;
            this.DefineAnimation();
        }
        /// <summary>
        /// Adds a Gameitem as a frame to the animation
        /// </summary>
        /// <param name="frame">gameitem used as frame</param>
        protected void AddFrame(GameItem frame)
        {
            this.frames.Add(frame);
        }

        /// <summary>
        /// The abstract function that defines the animation
        /// </summary>
        protected abstract void DefineAnimation();

        /// <summary>
        /// The method that plays the animation
        /// </summary>
        public void Play()
        {
            this.currentPosition = this.frames[0].Position;
            this.isPlaying = true;
            this.timesPlayed++;
        }

        /// <summary>
        /// Gets the current frame of the animation
        /// </summary>
        /// <returns>the current frame as a gameitem</returns>
        public GameItem GetStopedFrame()
        {
             GameItem renderedFrame = frames[currentFrame];
             renderedFrame.Position = currentPosition;
             return renderedFrame;
        }

        /// <summary>
        /// Updates the animation
        /// </summary>
        /// <param name="gametime">game's time</param>
        /// <returns>the frame to be rendered</returns>
        public GameItem Update(GameTime gametime)
        {
            if(this.movement.Count == 0)
                this.isPlaying = false;
            else if (this.checkMovementEnd(currentPosition))
                this.movement.Remove(this.movement[0]);
            //Set new frame
            GameItem renderedFrame = this.nextFrame();
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

        /// <summary>
        /// Sets the animation to the next frame
        /// </summary>
        /// <returns></returns>
        private GameItem nextFrame()
        {
            //Get the frame
            GameItem newFrame = frames[currentFrame];
            //Set it's position to the animation's position
            newFrame.Position = this.currentPosition;
            //Set counter for the next iteration or reset if all frames are looped over
            currentFrame = (currentFrame + 1) % frames.Count;
            return newFrame;
        }

        /// <summary>
        /// Calculates the new position of the animated item
        /// </summary>
        /// <param name="currentPosition">the current position of the item</param>
        /// <param name="movement">the movement to be done</param>
        /// <returns>the new position's vector</returns>
        private Vector2 getResultingVector(Vector2 currentPosition, Vector2 movement)
        {
            Vector2 displacementVector = movement - currentPosition;
            // Calculate the length (magnitude) of the displacement vector
            float distance = displacementVector.Length();
            // Calculate the unit vector (normalized displacement vector)
            Vector2 unitVector = Vector2.Normalize(displacementVector);
            // Calculate the resulting vector for one second
            Vector2 resultingVector = unitVector * speed;
            //Create a new calulator to apply modifications to resulting coordinates
            CoordinateCalculator calculator = new CoordinateCalculator();
            resultingVector.X = calculator.calculateCoordinate(currentPosition.X, 
                        this.movement[0].X, resultingVector.X);
            resultingVector.Y = calculator.calculateCoordinate(currentPosition.Y,
                        this.movement[0].Y, resultingVector.Y);

            return resultingVector;
        }

        private bool checkMovementEnd(Vector2 newPosition)
        {
            bool res = false;
            if (this.movement.Count > 0 && newPosition.X == this.movement[0].X && newPosition.Y == this.movement[0].Y)
                res = true;
            
            return res;
        }
    }
}
