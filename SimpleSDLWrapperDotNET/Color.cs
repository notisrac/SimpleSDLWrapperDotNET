using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SimpleSDLWrapperDotNET
{
    public class Color
    {
        public byte Red;
        public byte Green;
        public byte Blue;
        public byte Alpha;

        public Color()
        { }

        public Color(byte r, byte g, byte b, byte a)
        {
            Red = r;
            Green = g;
            Blue = b;
            Alpha = a;
        }

        public Color(int r, int g, int b, int a)
        {
            Red = (byte)r;
            Green = (byte)g;
            Blue = (byte)b;
            Alpha = (byte)a;
        }

        public byte[] ToRGBAByteArray()
        {
            byte[] baRet = new byte[] { Red, Green, Blue, Alpha };

            if (BitConverter.IsLittleEndian)
            {
                baRet = baRet.Reverse().ToArray();
            }

            return baRet;
        }

        public byte[] ToRGBByteArray()
        {
            byte[] baRet = new byte[] { Red, Green, Blue };

            if (BitConverter.IsLittleEndian)
            {
                baRet = baRet.Reverse().ToArray();
            }

            return baRet;
        }
    }
}
