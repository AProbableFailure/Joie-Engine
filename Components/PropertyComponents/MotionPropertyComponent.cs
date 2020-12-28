using Joie.Extensions;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.Components.Property
{
    public class MotionPropertyComponent
    {
        public Vector2 VelocityDirection { get; set; } = Vector2.Zero;
        public float Speed { get; set; } = 0;
        public Vector2 Velocity
        {
            get => VelocityDirection * Speed;
            set
            {
                VelocityDirection = value.SafeNormalize();
                Speed = VelocityDirection == Vector2.Zero ? 0 : value.Length();
            }
        }
    }
}
