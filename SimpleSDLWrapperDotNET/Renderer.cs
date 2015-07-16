using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SimpleSDLWrapperDotNET
{
    public class Renderer : IDisposable
    {
        public int Index { get; set; }
        public RendererFlags Flags { get; set; }
        public IntPtr Handle { get; set; }

        private bool disposed = false;

        /// <summary>
        /// Use this function to create a 2D rendering context for a window. 
        /// </summary>
        /// <param name="window">The window where rendering is displayed</param>
        /// <param name="index">The index of the rendering driver to initialize, or -1 to initialize the first one supporting the requested flags</param>
        /// <param name="flags">0, or one or more RendererFlags OR'd together</param>
        public Renderer(Window window, int index, RendererFlags flags)
        {
            Index = index;
            Flags = flags;
            Handle = SDL.SDL_CreateRenderer(window.Handle, index, (uint)flags);
            if (IntPtr.Zero == Handle)
            {
                throw new Exception("Error while trying to create a renderer: " + SDL.SDL_GetError());
            }
        }

        /// <summary>
        /// Use this function to create a 2D rendering context for a foreign window. 
        /// </summary>
        /// <param name="windowHandle">The handle of the foreign window</param>
        /// <param name="index">The index of the rendering driver to initialize, or -1 to initialize the first one supporting the requested flags</param>
        /// <param name="flags">0, or one or more RendererFlags OR'd together</param>
        public Renderer(IntPtr windowHandle, int index, RendererFlags flags)
        {
            Index = index;
            Flags = flags;
            Handle = SDL.SDL_CreateRenderer(windowHandle, index, (uint)flags);
            if (IntPtr.Zero == Handle)
            {
                throw new Exception("Error while trying to create a renderer: " + SDL.SDL_GetError());
            }
        }

        /// <summary>
        /// Use this function to clear the current rendering target with the drawing color. 
        /// </summary>
        public void Clear()
        {
            int iResult = SDL.SDL_RenderClear(Handle);
            if (0 != iResult)
            {
                throw new Exception("Error while trying to clear the renderer: " + SDL.SDL_GetError());
            }
        }

        /// <summary>
        /// Use this function to copy a portion of the texture to the current rendering target. 
        /// </summary>
        /// <param name="texture">The source texture</param>
        /// <param name="srcRect">The source SDL_Rect structure or NULL for the entire texture</param>
        /// <param name="dstRect">The destination SDL_Rect structure or NULL for the entire rendering target; the texture will be stretched to fill the given rectangle</param>
        public void RenderCopy(Texture texture, Rectangle srcRect, Rectangle dstRect)
        {
            if (null == texture)
            {
                throw new ArgumentNullException("texture", "Texture cannot be null!");
            }

            SDL.SDL_Rect sourceRect = srcRect;
            SDL.SDL_Rect destinationRect = dstRect;
            int iResult = 0;
            if (null == srcRect && null == dstRect)
            {
                iResult = SDL.SDL_RenderCopy(Handle, texture.Handle, IntPtr.Zero, IntPtr.Zero);
            }
            else if (null != srcRect && null == dstRect)
            {
                iResult = SDL.SDL_RenderCopy(Handle, texture.Handle, ref sourceRect, IntPtr.Zero);
            }
            else if (null == srcRect && null != dstRect)
            {
                iResult = SDL.SDL_RenderCopy(Handle, texture.Handle, IntPtr.Zero, ref destinationRect);
            }
            else if (null != srcRect && null != dstRect)
            {
                iResult = SDL.SDL_RenderCopy(Handle, texture.Handle, ref sourceRect, ref destinationRect);
            }
            if (0 != iResult)
            {
                throw new Exception("Error while trying to render the texture: " + SDL.SDL_GetError());
            }
        }

        /// <summary>
        /// Use this function to update the screen with rendering performed. 
        /// </summary>
        public void RenderPresent()
        {
            SDL.SDL_RenderPresent(Handle);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                SDL.SDL_DestroyRenderer(Handle);
                Handle = IntPtr.Zero;
            }

            disposed = true;
        }

        ~Renderer()
        {
            Dispose(false);
        }

    }
}
