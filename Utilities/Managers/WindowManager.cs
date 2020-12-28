using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.Utilities
{
    public static class WindowManager
    {
        private static Vector2 viewportSize;
        public static Vector2 ViewportSize
        {
            get => viewportSize;
            set
            {
                viewportSize = value;
                Game1._graphics.PreferredBackBufferWidth = (int)value.X;
                Game1._graphics.PreferredBackBufferHeight = (int)value.Y;
                Game1._graphics.ApplyChanges();
            }
        }
        //public static float LongerViewportLength { get => Math.Max(ViewportSize.X, ViewportSize.Y); }
        //public static float ShorterViewportLength { get => Math.Min(ViewportSize.X, ViewportSize.Y); }
    }
}
