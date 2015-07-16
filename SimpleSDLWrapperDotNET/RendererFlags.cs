using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SimpleSDLWrapperDotNET
{
    /// <summary>
    /// An enumeration of flags used when creating a rendering context. 
    /// </summary>
    [Flags]
    public enum RendererFlags
    {
        /// <summary>
        /// The renderer uses hardware acceleration
        /// </summary>
        RENDERER_ACCELERATED = SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED,
        /// <summary>
        /// Present is synchronized with the refresh rate
        /// </summary>
        RENDERER_PRESENTVSYNC = SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC,
        /// <summary>
        /// The renderer supports rendering to texture
        /// </summary>
        RENDERER_TARGETTEXTURE = SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE,
        /// <summary>
        /// The renderer is a software fallback
        /// </summary>
        RENDERER_SOFTWARE = SDL.SDL_RendererFlags.SDL_RENDERER_SOFTWARE
    }

}
