using Joie.ECS;
using Joie.Extensions;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.Components
{
    public class MovementComponent : Component, IBuildableComponent, IUpdatableComponent
    {
        public TransformComponent Transform { get; set; }//= new TransformComponent(registered: false);
        public Vector2 VelocityDirection { get; set; } = Vector2.Zero;
        public float Speed { get; set; } = 0;
        public Vector2 Velocity
        {
            get => VelocityDirection * Speed;
            set
            {
                VelocityDirection = value.SafeNormalize();//Vector2.Normalize(value);
                Speed = VelocityDirection == Vector2.Zero ? 0 : value.Length();
            }
        }

        public MovementComponent(bool registered = true) : base(registered)
        {
            //Transform = Entity.GetOrAddComponent(new TransformComponent(registered: false));
        }

        public void Component_Update(GameTime gameTime)
        {
            //Console.WriteLine("ha");
            //Entity.GetOrAddComponent(new TransformComponent()).Position += Velocity;
            //Entity.GetComponent<TransformComponent>().Position += Velocity;
            Transform.Position += Velocity;
        }

        public override void RegisterComponent()
        {
            Core.Builder.RegisterBuildable(this);
            Core.Physics.RegisterUpdatable(this);
        }

        public void Component_Initialize()
        {
            //throw new NotImplementedException();
            Transform = Entity.GetOrAddComponent(new TransformComponent(registered: false));
        }
    }
}
