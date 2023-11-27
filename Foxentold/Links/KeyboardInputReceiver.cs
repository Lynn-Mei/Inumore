using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxentold.Links
{
    public static class KeyboardInputReceiver
    {
        private static KeyboardState keyboardState;
        private static KeyboardState previousKeyboardState;
        public static KeyboardState currentKeyboardState { 
            set {
                previousKeyboardState = keyboardState;
                keyboardState = value;
            } 
        }

        public static bool IsKeyPressed(Keys key)
        {
            Keys[] pressedKeys = keyboardState.GetPressedKeys();
            return pressedKeys.Contains<Keys>(key); 
        }

        public static bool IsKeyNewPressed(Keys key)
        {
            Keys[] pressedKeys = keyboardState.GetPressedKeys();
            Keys[] oldpressedKeys = previousKeyboardState.GetPressedKeys();
            return pressedKeys.Contains<Keys>(key) && !oldpressedKeys.Contains<Keys>(key);
        }


    }
}
