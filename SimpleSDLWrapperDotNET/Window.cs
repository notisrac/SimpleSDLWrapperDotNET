using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SimpleSDLWrapperDotNET
{
    public class Window : IDisposable
    {
        public string Title { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public IntPtr Handle { get; private set; }
        public WindowFlags  Flags { get; private set; }

        private bool disposed = false;

        /// <summary>
        /// Creates a window with the specified position, dimensions, and flags. 
        /// </summary>
        /// <param name="title">The title of the window, in UTF-8 encoding</param>
        /// <param name="x">The x position of the window, SDL_WINDOWPOS_CENTERED, or SDL_WINDOWPOS_UNDEFINED</param>
        /// <param name="y">The y position of the window, SDL_WINDOWPOS_CENTERED, or SDL_WINDOWPOS_UNDEFINED</param>
        /// <param name="width">The width of the window</param>
        /// <param name="height">The height of the window</param>
        /// <param name="flags">0, or one or more SDL_WindowFlags OR'd together</param>
        public Window(string title, int x, int y, int width, int height, WindowFlags flags)
        {
            Title = title;
            if (string.IsNullOrEmpty(Title))
            {
                Title = "SDL window";
            }
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Flags = flags;
            // create the window
            Handle = SDL.SDL_CreateWindow(this.Title, this.X, this.Y, this.Width, this.Height, (SDL.SDL_WindowFlags)this.Flags);
            if (IntPtr.Zero == Handle)
            {
                throw new Exception("Error while trying to create the window: " + SDL.SDL_GetError());
            }
        }

        /// <summary>
        /// Use this function to create an SDL window from an existing native window. 
        /// </summary>
        /// <param name="windowHandle">a pointer to driver-dependent window creation data, typically your native window cast to a void*</param>
        public Window(IntPtr windowHandle)
        {
            // create the window
            Handle = SDL.SDL_CreateWindowFrom(windowHandle);
            if (IntPtr.Zero == Handle)
            {
                throw new Exception("Error while trying to create the window: " + SDL.SDL_GetError());
            }
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
                if (IntPtr.Zero != Handle)
                {
                    SDL.SDL_DestroyWindow(Handle);
                }
                Handle = IntPtr.Zero;
            }

            disposed = true;
        }

        ~Window()
        {
            Dispose(false);
        }
    }
}
