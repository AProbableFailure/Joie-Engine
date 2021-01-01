using Joie.ECS;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.Components
{
    public class TransformComponent : Component
    {
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public float Rotation { get; set; }

        public TransformComponent(Vector2 position, Vector2 scale, float rotation = 0, bool registered = true) : base(registered)
        {
            Position = position;
            Scale = scale;
            Rotation = rotation;
        }

        public TransformComponent(float positionX = 0, float positionY = 0, float scaleX = 1 , float scaleY = 1, float rotation = 0, bool registered = true) : base(registered)
        {
            Position = new Vector2(positionX, positionY);
            Scale = new Vector2(scaleX, scaleY);
            Rotation = rotation;
        }

        public override void RegisterComponent()
        {
            
        }
    }
}
