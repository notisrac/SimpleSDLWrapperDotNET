using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SimpleSDLWrapperDotNET
{
    public class KeyInformation
    {
        /// <summary>
        /// SDL physical key code
        /// </summary>
        public KeyScancode Scancode 
        {
            get { return (KeyScancode)BaseData.scancode; }
            
        }
        /// <summary>
        /// SDL virtual key code
        /// </summary>
        public KeyCode Keycode
        {
            get { return (KeyCode)BaseData.sym; }

        }
        /// <summary>
        /// Current key modifiers
        /// </summary>
        public KeyModifier Modifier
        {
            get { return (KeyModifier)BaseData.mod; }

        }

        private SDL.SDL_Keysym BaseData { get; set; }

        public KeyInformation(SDL.SDL_Keysym keyData)
        {
            BaseData = keyData;
        }
    }
}
