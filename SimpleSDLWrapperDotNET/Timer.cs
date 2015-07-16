using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SimpleSDLWrapperDotNET
{
    public class Timer
    {
        public uint StartTime { get; private set; }
        public uint StopTime { get; private set; }
        public bool isRunning { get; private set; }
        public TimeSpan ElapsedTime 
        { 
            get 
            {
                if (isRunning)
                {
                    return TimeSpan.Zero;
                }
                else
                {
                    return TimeSpan.FromMilliseconds(StopTime - StartTime);
                }
            }
        }

        public Timer()
        {
            isRunning = false;
            StartTime = 0;
        }

        public void Start()
        {
            if (!isRunning)
            {
                StartTime = SDL.SDL_GetTicks();
                isRunning = true;
            }
        }

        public void Stop()
        {
            if(isRunning)
            {
                StopTime = SDL.SDL_GetTicks();
                isRunning = false;
            }
        }
    }
}
