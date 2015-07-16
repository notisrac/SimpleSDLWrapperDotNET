using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SimpleSDLWrapperDotNET
{
    public class SDLWrapper : IDisposable
    {
        /// <summary>
        /// Initializes the first rendering driver supporting the requested flags = -1
        /// </summary>
        public const int DEFAULT_RENDERING_DRIVER = -1;
        public IntPtr Handle { get; private set; }

        private Window _window = null;
        public Window window
        {
            get
            {
                if (null == _window)
                {
                    throw new Exception("Create a window with CreateWindow() before using it!");
                }

                return _window;
            }
            private set { _window = value; }
        }


        private Renderer _renderer = null;
        public Renderer renderer
        {
            get
            {
                if (null == _renderer)
                {
                    throw new Exception("Create a renderer with CreateRenderer() before using it!");
                }

                return _renderer;
            }
            private set { _renderer = value; }
        }

        public uint pixelFormat { get; set; }

        private bool disposed = false;

        private const float FRAMERATECAP = 60f;
        private TimeSpan _totalElapsedTime = TimeSpan.Zero;
        private TimeSpan _targetElapsedTime = TimeSpan.FromSeconds(1 / FRAMERATECAP);

        private bool _isFrameRateCapped = true;
        private Timer _frameTimer = new Timer();

        /// <summary>
        /// Raised when the user ha requested a quit
        /// </summary>
        public event EventHandler<EventArgs> OnQuit;
        /// <summary>
        /// Raised when a key is pressed
        /// </summary>
        public event EventHandler<KeyboardEventArgs> OnKeyPressed;
        /// <summary>
        /// Raised when a key is released
        /// </summary>
        public event EventHandler<KeyboardEventArgs> OnKeyReleased;


        public SDLWrapper()
        {
            pixelFormat = SDL.SDL_PIXELFORMAT_RGBA8888;
        }

        /// <summary>
        /// Use this function to initialize the SDL library. This must be called before using any other SDL function. 
        /// </summary>
        /// <param name="flags">Subsystem initialization flags</param>
        public void Initialize(SDLInitFlags flags = SDLInitFlags.INIT_EVERYTHING)
        {
            int iInitResult = SDL.SDL_Init((uint)flags);
            if (0 != iInitResult)
            {
                throw new Exception("Error while trying to initialize SDL: " + SDL.SDL_GetError());
            }
        }

        public void InitializeTTF()
        {
            throw new NotImplementedException();
        }

        public void InitializePNG()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Use this function to create a window with the specified position, dimensions, and flags. 
        /// </summary>
        /// <param name="title">The title of the window, in UTF-8 encoding</param>
        /// <param name="x">The x position of the window, SDL_WINDOWPOS_CENTERED, or SDL_WINDOWPOS_UNDEFINED</param>
        /// <param name="y">The y position of the window, SDL_WINDOWPOS_CENTERED, or SDL_WINDOWPOS_UNDEFINED</param>
        /// <param name="width">The width of the window</param>
        /// <param name="height">The height of the window</param>
        /// <param name="flags">0, or one or more SDL_WindowFlags OR'd together</param>
        public void CreateWindow(string title, int x, int y, int width, int height, WindowFlags flags = WindowFlags.WINDOW_SHOWN)
        {
            window = new Window(title, x, y, width, height, flags);
        }

        /// <summary>
        /// Use this function to create an SDL window from an existing native window. 
        /// </summary>
        /// <param name="windowHandle">a pointer to driver-dependent window creation data, typically your native window cast to a void*</param>
        public void CreateWindowFor(IntPtr windowHandle)
        {
            window = new Window(windowHandle);
        }

        /// <summary>
        /// Use this function to create a 2D rendering context. 
        /// </summary>
        /// <param name="index">The index of the rendering driver to initialize, or DEFAULT_RENDERING_DRIVER to initialize the first one supporting the requested flags</param>
        /// <param name="flags">0, or one or more RendererFlags OR'd together</param>
        public void CreateRenderer(int index = DEFAULT_RENDERING_DRIVER, RendererFlags flags = RendererFlags.RENDERER_ACCELERATED)
        {
            renderer = new Renderer(window, index, flags);
        }

        /// <summary>
        /// Use this function to create a 2D rendering context for a window that was not created by SDL. 
        /// </summary>
        /// <param name="windowHandle">The handle of the foreign window</param>
        /// <param name="index">The index of the rendering driver to initialize, or -1 to initialize the first one supporting the requested flags</param>
        /// <param name="flags">0, or one or more RendererFlags OR'd together</param>
        public void CreateRendererForWindow(IntPtr windowHandle, int index = DEFAULT_RENDERING_DRIVER, RendererFlags flags = RendererFlags.RENDERER_ACCELERATED)
        {
            renderer = new Renderer(windowHandle, index, flags);
        }

        /// <summary>
        /// Creates a new dynamic texture, that can later be updated pixel by pixel
        /// </summary>
        /// <param name="width">Width of the texture</param>
        /// <param name="height">Height of the texture</param>
        /// <returns>A new dynamic texture</returns>
        public Texture CreateDynamicTexture(int width, int height)
        {
            return new Texture(renderer, pixelFormat, TextureAccessMode.TEXTUREACCESS_STREAMING, width, height);
        }

        /// <summary>
        /// Creates a texture from a BMP file
        /// </summary>
        /// <param name="fileName">The file containing a BMP image</param>
        /// <returns>A new texture containing the bitmap image</returns>
        public Texture CreateTextureFromBMP(string fileName)
        {
            return new Texture(renderer, fileName);
        }

        /// <summary>
        /// Use this function to clear the current rendering target with the drawing color. 
        /// </summary>
        public void ClearScreen()
        {
            renderer.Clear();
        }

        /// <summary>
        /// Use this function to render a texture to the rendering target
        /// </summary>
        /// <param name="texture">The source texture</param>
        public void RenderTexture(Texture texture)
        {
            renderer.RenderCopy(texture, null, null);
        }

        /// <summary>
        /// Use this function to render a texture to the rendering target
        /// </summary>
        /// <param name="texture">The source texture</param>
        /// <param name="source">The source rectangle or NULL for the entire texture</param>
        /// <param name="destination">The destination rectangle or NULL for the entire rendering target; the texture will be stretched to fill the given rectangle</param>
        public void RenderTexture(Texture texture, Rectangle source, Rectangle destination)
        {
            renderer.RenderCopy(texture, source, destination);
        }

        public void Render()
        {
            renderer.RenderPresent();
        }

        /// <summary>
        /// Use this function to handle currently pending events. 
        /// </summary>
        public void HandleEvents()
        {
            SDL.SDL_Event sdlEvent;
            while (SDL.SDL_PollEvent(out sdlEvent) != 0)
            {
                if (sdlEvent.type == SDL.SDL_EventType.SDL_QUIT)
                {
                    RaiseEvent(OnQuit, EventArgs.Empty);
                }
                else if (sdlEvent.type == SDL.SDL_EventType.SDL_KEYDOWN)
                {
                    RaiseEvent(OnKeyPressed, CreateEventArgs<KeyboardEventArgs>(sdlEvent));
                }
                else if (sdlEvent.type == SDL.SDL_EventType.SDL_KEYUP)
                {
                    RaiseEvent(OnKeyReleased, CreateEventArgs<KeyboardEventArgs>(sdlEvent));
                }
            }

        }

        /// <summary>
        /// Raises a new event
        /// </summary>
        /// <param name="eventHandler">The evenet handler that represents the event to raise</param>
        /// <param name="eventArgs">The event arguments that go with the raised event</param>
        private void RaiseEvent<T>(EventHandler<T> eventHandler, T eventArgs) where T : EventArgs
        {
            if (null != eventHandler)
            {
                eventHandler(this, eventArgs);
            }
        }

        /// <summary>
        /// Instantiates a new instance of the specified event args
        /// </summary>
        /// <typeparam name="T">The type of the event args to instantiate</typeparam>
        /// <param name="baseEvent">Parameter to pass for the new instance</param>
        /// <returns>A new instance of the eventargs specified by T</returns>
        private T CreateEventArgs<T>(SDL.SDL_Event baseEvent)
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { baseEvent });
        }


        /// <summary>A tick is equal to a single time step forward in the game state. During each tick, the game will update total game time,
        /// elapsed update time, and frame rates. It is important to note that the implementation is based on a Fixed Time Step algorithm where
        /// each update and draw occur in the same constant fixed intervals. Additionally, the game will call the Update and Draw game cycle
        /// methods to be overridden by each implementation's specific Game Update and Draw logic. This method is based heavily on MonoGame's
        /// tick implementation and suggestions from Glenn Fiedler's blog (http://gafferongames.com/game-physics/fix-your-timestep/).
        /// </summary>
        public void FrameRateCapper()
        {
            //while (_isFrameRateCapped && (_totalElapsedTime < _targetElapsedTime))
            if (_isFrameRateCapped)
            {
                _frameTimer.Stop();
                _totalElapsedTime = _frameTimer.ElapsedTime;
                _frameTimer.Start();
                //Console.WriteLine("{0}<{1}", _totalElapsedTime.TotalMilliseconds, _targetElapsedTime.TotalMilliseconds);

                if (_isFrameRateCapped && (_totalElapsedTime < _targetElapsedTime))
                {
                    TimeSpan sleepTime = _targetElapsedTime - _totalElapsedTime;
                    SDL.SDL_Delay((UInt32)sleepTime.TotalMilliseconds);
                    Console.WriteLine("{0}<{1}={2}", _totalElapsedTime.TotalMilliseconds, _targetElapsedTime.TotalMilliseconds, sleepTime.TotalMilliseconds);
                }
            }

            //// cap the total elapsed time, to prevent overcopmensation
            //if (totalElapsedTime > TimeSpan.FromSeconds(0.5))
            //{
            //    totalElapsedTime = TimeSpan.FromSeconds(0.5);
            //}

            //    if (isFrameRateCapped)
            //    {
            //        int stepCount = 0;

            //        while (accumulatedElapsedTime >= targetElapsedTime)
            //        {
            //            gameTime.TotalGameTime += targetElapsedTime;
            //            accumulatedElapsedTime -= targetElapsedTime;
            //            stepCount++;

            //            Update(gameTime);
            //        }

            //        gameTime.ElapsedGameTime = TimeSpan.FromTicks(targetElapsedTime.Ticks * stepCount);
            //    }
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
                if (null != renderer)
                {
                    renderer.Dispose();
                }
                if (null != window)
                {
                    window.Dispose();
                }

                SDL.SDL_Quit();
            }

            disposed = true;
        }

        ~SDLWrapper()
        {
            Dispose(false);
        }
    }
}
