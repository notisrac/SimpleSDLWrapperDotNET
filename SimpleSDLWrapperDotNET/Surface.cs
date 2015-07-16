using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;
using System.Runtime.InteropServices;

namespace SimpleSDLWrapperDotNET
{
    public class Surface
    {
        public IntPtr Handle { get; private set; }
        public string FileName { get; private set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private bool disposed = false;


        /// <summary>
        /// Use this function to load a surface from a BMP file. 
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="fileName">The file containing a BMP image</param>
        public Surface(Renderer renderer, string fileName)
        {
            Handle = SDL.SDL_LoadBMP(fileName);
            if (IntPtr.Zero == Handle)
            {
                throw new Exception("Error while loading bitmap: " + SDL.SDL_GetError());
            }
            _getSurfaceProperties();
        }

        private void _getSurfaceProperties()
        {
            if (IntPtr.Zero == Handle)
            {
                throw new Exception("Surface must be created first");
            }
            SDL.SDL_Surface rawSurface = (SDL.SDL_Surface)Marshal.PtrToStructure(Handle, typeof(SDL.SDL_Surface));
            Width = rawSurface.w;
            Height = rawSurface.h;
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
                SDL.SDL_FreeSurface(Handle);
                Handle = IntPtr.Zero;
            }

            disposed = true;
        }

        ~Surface()
        {
            Dispose(false);
        }

    }
}
