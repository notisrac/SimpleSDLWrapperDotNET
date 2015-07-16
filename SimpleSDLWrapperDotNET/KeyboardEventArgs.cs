using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSDLWrapperDotNET
{
    /// <summary>
    /// An event argument that contains keyboard button event information. 
    /// </summary>
    public class KeyboardEventArgs : BaseEventArgs
    {
        /// <summary>
        /// Non-zero if this is a key repeat
        /// </summary>
        public byte Repeat
        {
            get { return BaseEvent.key.repeat; }
        }
        /// <summary>
        /// The state of the key; SDL_PRESSED or SDL_RELEASED
        /// </summary>
        public KeyState State
        {
            get { return (KeyState)BaseEvent.key.state; }
        }
        public KeyInformation KeyInfo
        {
            get { return new KeyInformation(BaseEvent.key.keysym); }
        }

        public KeyboardEventArgs(SDL.SDL_Event baseEvent)
            : base(baseEvent)
        {
            WindowID = baseEvent.key.windowID;
        }
    }
}
