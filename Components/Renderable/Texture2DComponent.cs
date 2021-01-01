using Joie.ECS;
using Joie.Extensions;
using Joie.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.Components
{
    
    public class Texture2DComponent : Component, IRenderableComponent
    {
        public Texture2D Texture { get; set; }
        public Vector2 TextureSize 
            => new Vector2(Texture.Width, Texture.Height);
        public Vector2 SourceRectanglePosition { get; set; }
        public Vector2 SourceRectangleSize { get; set; }
        
        public Rectangle SourceRectangle 
            => new Rectangle(SourceRectanglePosition.ToPoint(), SourceRectangleSize.ToPoint());
        
        public Texture2DComponent(string textureName
                                , float xPos = 0, float yPos = 0
                                , float xSize = 1, float ySize = 1
                                , DivisionMethod division = DivisionMethod.Fractional
                                , bool register = true) : base(register)
        {
            Texture = Core.Renderer.SceneTextures[textureName];

            SourceRectanglePosition = new Vector2(xPos, yPos).ApplyDivisionMethod(division, TextureSize);
            SourceRectangleSize = new Vector2(xSize, ySize).ApplyDivisionMethod(division, TextureSize);
        }

        public void Component_Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture
                            //, new Vector2(100, 100)
                            , Entity.GetOrAddComponent(new TransformComponent(registered: false)).Position
                            , SourceRectangle
                            , Color.White);
        }

        public override void RegisterComponent()
        {
            Core.Renderer.RegisterRenderable(this);
        }
    }
}
