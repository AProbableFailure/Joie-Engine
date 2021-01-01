using Joie.ECS;
using Joie.Extensions;
using Joie.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joie.Components
{

    public class AnimationComponent : Component
    {
        //public string TextureName
        public Dictionary<Func<bool>, Animation> Animations = new Dictionary<Func<bool>, Animation>();
        private Animation _currentAnimation;
        public Animation CurrentAnimation 
        {
            get => _currentAnimation ?? Animations.Values.First();
            set => _currentAnimation = value;
        }
        private float timer = 0f;

        public AnimationComponent(bool register = true) : base(register)
        {
            //Core.Renderer.Register(this);
        }

        public override void RegisterComponent()
        {
            Core.Renderer.Register(this);
        }

        public void AddAnimation(Func<bool> trigger, Animation animation)
            => Animations.Add(trigger, animation);

        public void SetAnimation()
        {
            foreach (var animation in Animations)
            {
                if (animation.Key())
                {
                    Play(animation.Value);
                }
            }
        }

        public void Play(Animation animation)
        {
            if (CurrentAnimation == animation)
                return;

            CurrentAnimation = animation;
            CurrentAnimation.CurrentFrame = 0;

            timer = 0f;
        }

        public void Stop()
        {
            timer = 0f;
            CurrentAnimation.CurrentFrame = 0;
        }

        public void Component_Update(GameTime gameTime)
        {
            SetAnimation();

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > CurrentAnimation.AnimationSpeed)
            {
                timer = 0f;

                CurrentAnimation.CurrentFrame++;

                if (CurrentAnimation.CurrentFrame >= CurrentAnimation.FrameCount)
                    CurrentAnimation.CurrentFrame = 0;
            }
        }

        public void Component_Draw(SpriteBatch spriteBatch)//, Texture2D texture)
        {
            //var textureSize = new Vector2(texture.Width, texture.Height);
            //Console.WriteLine(CurrentAnimation.FrameHeight);

            //CurrentAnimation.CurrentFrame++;
            //if (CurrentAnimation.CurrentFrame >= CurrentAnimation.FrameCount)
            //    CurrentAnimation.CurrentFrame = 0;

            spriteBatch.Draw(CurrentAnimation.TextureComponent.Texture//texture
                            , new Vector2(100, 100)
                            , CurrentAnimation.SourceRectangle//new Rectangle(C
                            
                            //SourceRectangle
                              //CurrentAnimation.Division == DivisionMethod.ByPixel
                              //  ? CurrentAnimation.SourceRectangle
                              //  : new Rectangle((textureSize * SourceRectanglePosition).ToPoint(), (textureSize * SourceRectangleSize).ToPoint())
                            , Color.White);


            //spriteBatch.Draw(CurrentAnimation.Texture
            //                , ParentEntity.Position
            //                , new Rectangle(CurrentAnimation.FrameWidth * (CurrentAnimation.CurrentFrame % CurrentAnimation.Columns)
            //                                , CurrentAnimation.FrameHeight * (int)MathF.Floor(CurrentAnimation.CurrentFrame / CurrentAnimation.Columns)
            //                                , CurrentAnimation.FrameWidth
            //                                , CurrentAnimation.FrameHeight)
            //                , Color.White
            //                , 0f, Vector2.Zero
            //                , 1
            //                , ParentEntity.FacingRight ? SpriteEffects.None : SpriteEffects.FlipHorizontally
            //                , 1); //Height);


            //spriteBatch.Draw(CurrentAnimation.SpriteSheet
            //                , ParentEntity.Position
            //                , new Rectangle(CurrentAnimation.FrameWidth * (CurrentAnimation.CurrentFrame % CurrentAnimation.Columns)
            //                                , CurrentAnimation.FrameHeight * (int)MathF.Floor(CurrentAnimation.CurrentFrame / CurrentAnimation.Columns)
            //                                , CurrentAnimation.FrameWidth
            //                                , CurrentAnimation.FrameHeight)
            //                , Color.White
            //                , 0f, Vector2.Zero
            //                , 1
            //                , ParentEntity.FacingRight ? SpriteEffects.None : SpriteEffects.FlipHorizontally
            //                , 1); //Height);
        }
    }

    public class Animation
    {
        //public DivisionMethod Division { get; set; }
        public Texture2DComponent TextureComponent { get; set; }
        public Vector2 SourceRectanglePosition { get; set; }
        //public Vector2 SourceRectangleSize { get; set; }
        public Rectangle SourceRectangle
        {
            get
            {
                return new Rectangle((LocalSourceRectanglePosition + TextureComponent.SourceRectanglePosition).ToPoint(), new Point((int)FrameWidth, (int)FrameHeight));
            }
        }
        //public Rectangle SourceRectangle { get => new Rectangle((SourceRectanglePosition + Texture.SourceRectanglePosition).ToPoint()
        //    , SourceRectangleSize.ToPoint()); }
        public Vector2 LocalSourceRectanglePosition
        {
            get => new Vector2(FrameWidth * (CurrentFrame % Columns)
                                , FrameHeight * MathF.Floor(CurrentFrame / Columns));
        }

        public int CurrentFrame { get; set; }
        public float AnimationSpeed { get; set; }
        public bool IsLooping { get; set; } = true;
        public int FrameCount { get; set; }
        public float FrameWidth { get; set; }
        public float FrameHeight { get; set; }

        public int Columns { get; set; }
        public int Rows { get; set; }

        public Animation(Texture2DComponent texture, float xFrameSize = 1, float yFrameSize = 1, DivisionMethod division = DivisionMethod.Fractional, float speed = 10f)
        {
            TextureComponent = texture;

            AnimationSpeed = 1/speed;

            //if (division == DivisionMethod.Fractional)
            //{
            //    //Console.WriteLine(texture.SourceRectangleSize.X * xFrameSize);
            //    FrameWidth = texture.SourceRectangleSize.X * xFrameSize;
            //    FrameHeight = texture.SourceRectangleSize.Y * yFrameSize;
            //}
            //else
            //{
            //    FrameWidth = xFrameSize;
            //    FrameHeight = yFrameSize;
            //}
            var frameSize = new Vector2(xFrameSize, yFrameSize).ApplyDivisionMethod(division, texture.SourceRectangleSize);
            FrameWidth = frameSize.X;
            FrameHeight = frameSize.Y;

            //X
            Columns = (int)(1 / xFrameSize);
            //Y
            Rows = (int)(1 / yFrameSize);

            FrameCount = Columns * Rows;
        }
    }
}
