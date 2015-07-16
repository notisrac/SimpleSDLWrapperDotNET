using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SimpleSDLWrapperDotNET
{
    /// <summary>
    /// A structure that defines a rectangle, with the origin at the upper left. 
    /// </summary>
    public class Rectangle
    {
        /// <summary>
        /// The x location of the rectangle's upper left corner
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// The y location of the rectangle's upper left corner
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// The width of the rectangle
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// The height of the rectangle
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Create a new rectangle instance
        /// </summary>
        public Rectangle()
        { }

        /// <summary>
        /// Create a new rectangle instance
        /// </summary>
        /// <param name="x">The x location of the rectangle's upper left corner</param>
        /// <param name="y">The y location of the rectangle's upper left corner</param>
        /// <param name="width">The width of the rectangle</param>
        /// <param name="height">The height of the rectangle</param>
        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Height = height;
            Width = width;
        }

        public static implicit operator SDL.SDL_Rect(Rectangle rect)
        {
            if (null == rect)
            {
                return new SDL.SDL_Rect(){ x = 0, y = 0, h = 0, w = 0 };
            }
            return new SDL.SDL_Rect() { x = rect.X, y = rect.Y, h = rect.Height, w = rect.Width };
        }

        public static implicit operator Rectangle(SDL.SDL_Rect rect)
        {
            if (SDL.SDL_bool.SDL_TRUE == SDL.SDL_RectEmpty(ref rect))
            {
                return null;
            }
            return new Rectangle(rect.x, rect.y, rect.w, rect.h);
        }
    }
}
