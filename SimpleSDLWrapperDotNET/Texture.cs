using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSDLWrapperDotNET
{
    public class Texture : IDisposable
    {
        public IntPtr Handle { get; private set; }
        public uint pixelFormat { get; private set; }
        public TextureAccessMode accessMode { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Pitch { get; private set; }
        public bool isLocked { get; private set; }


        private IntPtr PixelsPointer;


        private bool disposed = false;

        /// <summary>
        /// Creates a texture for a rendering context. 
        /// </summary>
        /// <param name="renderer">The rendering context</param>
        /// <param name="pixelFormat">One of the enumerated values in SDL_PixelFormatEnum</param>
        /// <param name="accessMode">One of the enumerated values in SDL_TextureAccess</param>
        /// <param name="width">The width of the texture in pixels</param>
        /// <param name="height">The height of the texture in pixels</param>
        public Texture(Renderer renderer, uint pixelFormat , TextureAccessMode accessMode, int width, int height)
        {
            this.pixelFormat = pixelFormat;
            this.accessMode = accessMode;
            Width = width;
            Height = height;
            isLocked = false;

            Handle = SDL.SDL_CreateTexture(renderer.Handle, pixelFormat, (int)accessMode, width, height);
            if (IntPtr.Zero == Handle)
            {
                throw new Exception("Error while creating texture: " + SDL.SDL_GetError());

            }
        }

        /// <summary>
        /// Creates a texture from an existing surface. 
        /// </summary>
        /// <param name="renderer">The rendering context</param>
        /// <param name="surface">The SDL_Surface structure containing pixel data used to fill the texture</param>
        //public Texture(Renderer renderer, Surface surface)
        //{
        //    this.pixelFormat = surface.pixelFormat;
        //    this.accessMode = TextureAccessMode.TEXTUREACCESS_STATIC;
        //    Width = surface.Width;
        //    Height = surface.Height;

        //    Handle = SDL.SDL_CreateTextureFromSurface(renderer.Handle, surface);
        //    if (IntPtr.Zero == Handle)
        //    {
        //        throw new Exception("Error while creating texture from surface: " + SDL.SDL_GetError());

        //    }
        //}

        /// <summary>
        /// Use this function to load a texture from a BMP file. 
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="fileName">The file containing a BMP image</param>
        public Texture(Renderer renderer, string fileName)
        {
            Surface sSurface = new Surface(renderer, fileName);

            Handle = SDL.SDL_CreateTextureFromSurface(renderer.Handle, sSurface.Handle);
            if (IntPtr.Zero == Handle)
            {
                throw new Exception("Error while creating texture from bitmap: " + SDL.SDL_GetError());

            }
            Height = sSurface.Height;
            Width = sSurface.Width;
            accessMode = TextureAccessMode.TEXTUREACCESS_STATIC;

            sSurface.Dispose();
        }


        /// <summary>
        /// Use this function to lock a portion of the texture for write-only pixel access. 
        /// You must use SDL_UnlockTexture() to unlock the pixels and apply any changes. 
        /// </summary>
        /// <returns>The pitch value of the texture</returns>
        public int Lock()
        {
            if (accessMode != TextureAccessMode.TEXTUREACCESS_STREAMING)
            {
                throw new InvalidOperationException("Only textures with access mode streaming can be locked!");
            }

            int iPitch;
            int iResult = SDL.SDL_LockTexture(Handle, IntPtr.Zero, out PixelsPointer, out iPitch);
            // Returns 0 on success or a negative error code if the texture is not valid or was not created with SDL_TEXTUREACCESS_STREAMING
            if(0 != iResult)
            {
                throw new Exception("Error while trying to lock the texture: " + SDL.SDL_GetError());
            }
            Pitch = iPitch;
            isLocked = true;

            return iPitch;
        }

        /// <summary>
        /// Use this function to unlock a texture, uploading the changes to video memory, if needed.
        /// </summary>
        public void Unlock()
        {
            if (!isLocked)
            {
                throw new InvalidOperationException("Texture is not locked!");
            }
            SDL.SDL_UnlockTexture(Handle);
            PixelsPointer = IntPtr.Zero;
            isLocked = false;
        }

        public void SetPixels(Color[] pixels)
        {
            if(IntPtr.Zero == PixelsPointer)
            {
                throw new Exception("Empty texture pixels position pointer!");
            }

            byte[] baTMP = new byte[Pitch * Height];
            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i].ToRGBAByteArray().CopyTo(baTMP, i * 4);
            }

            unsafe
            {
                // copy the pixels into the texture - this means copying a bunch of bytes onto a memory location
                Marshal.Copy(baTMP, 0, PixelsPointer, baTMP.Length);
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
                SDL.SDL_DestroyTexture(Handle);
                Handle = IntPtr.Zero;
            }

            disposed = true;
        }

        ~Texture()
        {
            Dispose(false);
        }
    }
}
