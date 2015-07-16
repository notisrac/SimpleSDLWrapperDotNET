using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSDLWrapperDotNET;
using SimpleSDLWrapperDotNET.Mixer;

namespace TestApp
{
    class Program
    {
        private static Random rndRandom = new Random();
        private static bool bRunning = true;
        private static AudioSample sample;
        private static int delay = 0;

        static void Main(string[] args)
        {
            SDLWrapper sdl = new SDLWrapper();
            sdl.Initialize();
            sdl.CreateWindow("Test window", 100, 100, 640, 320, WindowFlags.WINDOW_SHOWN);
            sdl.CreateRenderer(SDLWrapper.DEFAULT_RENDERING_DRIVER, RendererFlags.RENDERER_ACCELERATED/* | RendererFlags.RENDERER_PRESENTVSYNC*/);
            Texture txDisplayTexture = sdl.CreateDynamicTexture(64, 32);

            sdl.OnQuit += sdl_onQuit;
            sdl.OnKeyPressed += sdl_OnKeyPressedOrReleased;
            sdl.OnKeyReleased += sdl_OnKeyPressedOrReleased;

            SDLMixerWrapper mixer = new SDLMixerWrapper();
            mixer.Initialize();
            sample = mixer.LoadSample(@"Ding.wav");

            bRunning = true;
            while (bRunning)
            {
                // call this at the beginning of ever loop to capture the events
                sdl.HandleEvents();

                //sdl.FrameRateCapper();
                System.Threading.Thread.Sleep(delay);

                Color[] caPixelPile = new Color[64 * 32];
                for (int i = 0; i < caPixelPile.Length; i++)
                {
                    caPixelPile[i] = new Color(rndRandom.Next(255), rndRandom.Next(255), rndRandom.Next(255), rndRandom.Next(255));
                }
                txDisplayTexture.Lock();
                txDisplayTexture.SetPixels(caPixelPile);
                txDisplayTexture.Unlock();


                sdl.ClearScreen();
                sdl.RenderTexture(txDisplayTexture);
                sdl.Render();
            }
        }

        static void sdl_OnKeyPressedOrReleased(object sender, KeyboardEventArgs e)
        {
            if (null == e)
            {
                Console.WriteLine("Key pressed: empty key data!!!!");
            }
            else
            {
                Console.WriteLine("Key pressed: code:{0} state:{1} repeat:{2} mod:{3}", e.KeyInfo.Scancode, e.State, e.Repeat, e.KeyInfo.Modifier);
                if (e.KeyInfo.Scancode == KeyScancode.A && e.State == KeyState.PRESSED)
                {
                    sample.Play();
                }
                else if (e.KeyInfo.Scancode == KeyScancode.NumPadPlus && e.State == KeyState.PRESSED)
                {
                    delay++;
                }
                else if (e.KeyInfo.Scancode == KeyScancode.NumPadMinus && e.State == KeyState.PRESSED)
                {
                    delay--;
                }
            }
        }

        static void sdl_onQuit(object sender, EventArgs e)
        {
            bRunning = false;
        }
    }
}
