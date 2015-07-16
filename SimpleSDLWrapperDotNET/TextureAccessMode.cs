using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSDLWrapperDotNET
{
    /// <summary>
    /// An enumeration of texture access patterns. 
    /// </summary>
    public enum TextureAccessMode
    {
        /// <summary>
        /// Changes rarely, not lockable
        /// </summary>
        TEXTUREACCESS_STATIC = SDL.SDL_TextureAccess.SDL_TEXTUREACCESS_STATIC,
        /// <summary>
        /// Changes frequently, lockable
        /// </summary>
        TEXTUREACCESS_STREAMING = SDL.SDL_TextureAccess.SDL_TEXTUREACCESS_STREAMING,
        /// <summary>
        /// Can be used as a render target
        /// </summary>
        TEXTUREACCESS_TARGET = SDL.SDL_TextureAccess.SDL_TEXTUREACCESS_TARGET
    }
}
