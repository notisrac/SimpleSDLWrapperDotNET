using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SimpleSDLWrapperDotNET
{
    public abstract class BaseEventArgs : EventArgs
    {
        protected SDL.SDL_Event BaseEvent { get; private set; }
        public uint WindowID { get; set; }

        public BaseEventArgs(SDL.SDL_Event baseEvent)
        {
            BaseEvent = baseEvent;
        }
    }
}
