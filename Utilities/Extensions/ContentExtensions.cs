using Joie.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.Extensions
{
    public static class ContentExtensions
    {
        public static float ApplyDivisionMethod(this float raw, DivisionMethod division, float apply)
        {
            switch (division)
            {
                case DivisionMethod.Fractional:
                    return apply * raw;
                case DivisionMethod.ByPixel:
                    return raw;
                default:
                    return raw;
            }
        }
        public static Vector2 ApplyDivisionMethod(this Vector2 raw, DivisionMethod division, Vector2 apply)
        {
            switch (division)
            {
                case DivisionMethod.Fractional:
                    return apply * raw;
                case DivisionMethod.ByPixel:
                    return raw;
                default:
                    return raw;
            }
        }
    }
}
