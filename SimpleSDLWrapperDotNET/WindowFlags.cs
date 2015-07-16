using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SimpleSDLWrapperDotNET
{
    /// <summary>
    /// An enumeration of window states. 
    /// </summary>
    [Flags]
    public enum WindowFlags
    {
        /// <summary>
        /// Window is visible
        /// </summary>
        WINDOW_SHOWN = SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN,
        /// <summary>
        /// Fullscreen window
        /// </summary>
        WINDOW_FULLSCREEN = SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN,
        /// <summary>
        /// Fullscreen window at the current desktop resolution
        /// </summary>
        WINDOW_FULLSCREEN_DESKTOP = SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP,
        /// <summary>
        /// Window usable with OpenGL context
        /// </summary>
        WINDOW_OPENGL = SDL.SDL_WindowFlags.SDL_WINDOW_OPENGL,
        /// <summary>
        /// Window is not visible
        /// </summary>
        WINDOW_HIDDEN = SDL.SDL_WindowFlags.SDL_WINDOW_HIDDEN,
        /// <summary>
        /// No window decoration
        /// </summary>
        WINDOW_BORDERLESS = SDL.SDL_WindowFlags.SDL_WINDOW_BORDERLESS,
        /// <summary>
        /// Window can be resized
        /// </summary>
        WINDOW_RESIZABLE = SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE,
        /// <summary>
        /// Window is minimized
        /// </summary>
        WINDOW_MINIMIZED = SDL.SDL_WindowFlags.SDL_WINDOW_MINIMIZED,
        /// <summary>
        /// Window is maximized
        /// </summary>
        WINDOW_MAXIMIZE = SDL.SDL_WindowFlags.SDL_WINDOW_MAXIMIZED,
        /// <summary>
        /// Window has grabbed input focus
        /// </summary>
        WINDOW_INPUT_GRABBED = SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_GRABBED,
        /// <summary>
        /// Window has input focus
        /// </summary>
        WINDOW_INPUT_FOCUS = SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_FOCUS,
        /// <summary>
        /// Window has mouse focus
        /// </summary>
        WINDOW_MOUSE_FOCUS = SDL.SDL_WindowFlags.SDL_WINDOW_MOUSE_FOCUS,
        /// <summary>
        /// Window not created by SDL
        /// </summary>
        WINDOW_FOREIGN = SDL.SDL_WindowFlags.SDL_WINDOW_FOREIGN
    }
}
