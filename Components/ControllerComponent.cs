using Joie.ECS;
using Joie.Extensions;
using Joie.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.Components
{
    public class ControllerComponent : Component, IBuildableComponent, IUpdatableComponent
    {
        MovementComponent Movement { get; set; }
        const float crouchSpeed = 1f;
        const float walkSpeed = 2f;
        const float sprintSpeed = 4f;

        //public void InitializeComponent()
        //{
        //    Movement = ParentEntity.GetOrAddComponent<MovementComponent>();
        //}

        public ControllerComponent(bool registered = true) : base(registered)
        {
            //Movement = Entity.GetOrAddComponent(new MovementComponent(true));
        }

        public void Component_Update(GameTime gameTime)
        {
            Move();
        }

        public void Move()
        {
            float horIn = Convert.ToInt16(InputManager.IsInput(InputManager.Down, Inputs.Right))
                        - Convert.ToInt16(InputManager.IsInput(InputManager.Down, Inputs.Left));
            float verIn = Convert.ToInt16(InputManager.IsInput(InputManager.Down, Inputs.Down))
                        - Convert.ToInt16(InputManager.IsInput(InputManager.Down, Inputs.Up));

            Movement.VelocityDirection = new Vector2(horIn, verIn).SafeNormalize(); //!(horIn == 0 && verIn == 0) ? Vector2.Normalize(new Vector2(horIn, verIn)) : Vector2.Zero;
            Movement.Speed = Movement.VelocityDirection == Vector2.Zero ? 0
                            : InputManager.IsInput(InputManager.Down, Inputs.Sprint) ? sprintSpeed
                            : InputManager.IsInput(InputManager.Down, Inputs.Crouch) ? crouchSpeed
                            : walkSpeed;

            //Entity.GetOrAddComponent(new MovementComponent(true)).VelocityDirection = new Vector2(horIn, verIn).SafeNormalize(); //!(horIn == 0 && verIn == 0) ? Vector2.Normalize(new Vector2(horIn, verIn)) : Vector2.Zero;
            //Entity.GetOrAddComponent(new MovementComponent(true)).Speed = Entity.GetOrAddComponent(new MovementComponent(true)).VelocityDirection == Vector2.Zero ? 0
            //                : InputManager.IsInput(InputManager.Down, Inputs.Sprint) ? sprintSpeed
            //                : InputManager.IsInput(InputManager.Down, Inputs.Crouch) ? crouchSpeed
            //                : walkSpeed;

            //Entity.GetComponent<MovementComponent>().VelocityDirection = new Vector2(horIn, verIn).SafeNormalize(); //!(horIn == 0 && verIn == 0) ? Vector2.Normalize(new Vector2(horIn, verIn)) : Vector2.Zero;
            //Entity.GetComponent<MovementComponent>().Speed = Entity.GetComponent<MovementComponent>().VelocityDirection == Vector2.Zero ? 0
            //                : InputManager.IsInput(InputManager.Down, Inputs.Sprint) ? sprintSpeed
            //                : InputManager.IsInput(InputManager.Down, Inputs.Crouch) ? crouchSpeed
            //                : walkSpeed;

            //if (Movement.VelocityDirection.X != 0f)
            //{
            //    Entity.FacingRight = Movement.VelocityDirection.X > 0;
            //}
        }

        public override void RegisterComponent()
        {
            Core.Builder.RegisterBuildable(this);
            Core.Physics.RegisterUpdatable(this);
            //throw new NotImplementedException();
        }

        public void Component_Initialize()
        {
            Movement = Entity.GetOrAddComponent(new MovementComponent(true));
            //throw new NotImplementedException();
        }
    }
}
