using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SimpleSDLWrapperDotNET
{
    /// <summary>
    /// The state of the key
    /// </summary>
    public enum KeyState
    {
        PRESSED = SDL.SDL_PRESSED,
        RELEASED = SDL.SDL_RELEASED
    }
}
