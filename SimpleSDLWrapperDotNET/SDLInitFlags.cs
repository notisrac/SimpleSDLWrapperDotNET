using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SimpleSDLWrapperDotNET
{
    [Flags]
    public enum SDLInitFlags
    {
        /// <summary>
        /// Audio subsystem
        /// </summary>
        INIT_AUDIO = (int)SDL.SDL_INIT_AUDIO,
        /// <summary>
        /// All of the above subsystems
        /// </summary>
        INIT_EVERYTHING = (int)SDL.SDL_INIT_EVERYTHING,
        /// <summary>
        /// Controller subsystem
        /// </summary>
        INIT_GAMECONTROLLER = (int)SDL.SDL_INIT_GAMECONTROLLER,
        /// <summary>
        /// Haptic (force feedback) subsystem
        /// </summary>
        INIT_HAPTIC = (int)SDL.SDL_INIT_HAPTIC,
        /// <summary>
        /// Joystick subsystem
        /// </summary>
        INIT_JOYSTICK = (int)SDL.SDL_INIT_JOYSTICK,
        /// <summary>
        /// Compatibility; this flag is ignored
        /// </summary>
        INIT_NOPARACHUTE = (int)SDL.SDL_INIT_NOPARACHUTE,
        /// <summary>
        /// Timer subsystem
        /// </summary>
        INIT_TIMER = (int)SDL.SDL_INIT_TIMER,
        /// <summary>
        /// Video subsystem
        /// </summary>
        INIT_VIDEO = (int)SDL.SDL_INIT_VIDEO
    }
}
