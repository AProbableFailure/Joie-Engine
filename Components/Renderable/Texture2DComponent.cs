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
    
    public class Texture2DComponent : Component
    {
        public Texture2D Texture { get; set; }
        public Vector2 TextureSize { get => new Vector2(Texture.Width, Texture.Height); }
        public DivisionMethod Division { get; set; }
        public Vector2 SourceRectanglePosition { get; set; }
        public Vector2 SourceRectangleSize { get; set; }
        
        public Rectangle SourceRectangle 
            => new Rectangle(SourceRectanglePosition.ToPoint(), SourceRectangleSize.ToPoint());
        
        
        //(SourceRectanglePosition.X, SourceRectangle.Y, (int)SourceRectangleSize.X, (int)SourceRectangleSize.Y); }

        public Texture2DComponent(string textureName, float xPos = 0, float yPos = 0, float xSize = 1, float ySize = 1, DivisionMethod division = DivisionMethod.Fractional, bool register = true) : base(register)
        {
            //TextureName = textureName;
            Texture = Core.Renderer.SceneTextures[textureName];
            Division = division;

            //if (division == DivisionMethod.Fractional)
            //{
            //    //Console.WriteLine("T" + TextureSize);
            //    //Console.WriteLine("SDFDSF " + new Vector2(xSize, ySize) * TextureSize);
            //    SourceRectanglePosition = new Vector2(xPos, yPos) * TextureSize;
            //    SourceRectangleSize = new Vector2(xSize, ySize) * TextureSize;
            //}
            //else //if (division == DivisionMethod)
            //{
            //    SourceRectanglePosition = new Vector2(xPos, yPos);
            //    SourceRectangleSize = new Vector2(xSize, ySize);
            //}
            SourceRectanglePosition = new Vector2(xPos, yPos).ApplyDivisionMethod(division, TextureSize);
            SourceRectangleSize = new Vector2(xSize, ySize).ApplyDivisionMethod(division, TextureSize);

            if (register)
                RegisterComponent();

            //SourceRectanglePosition = new Vector2(xPos, yPos);
            //SourceRectangleSize = new Vector2(xSize, ySize);

            //Console.WriteLine(SourceRectangleSize);
        }

        public void Component_Draw(SpriteBatch spriteBatch)//, Texture2D texture)
        {
            //var textureSize = new Vector2(Texture.Width, Texture.Height);
            spriteBatch.Draw(Texture
                            , new Vector2(100, 100)
                            , SourceRectangle
                            //, Division == DivisionMethod.ByPixel
                            //    ? SourceRectangle
                            //    : new Rectangle((textureSize * SourceRectanglePosition).ToPoint(), (textureSize * SourceRectangleSize).ToPoint())
                            , Color.White);
        }

        public override void RegisterComponent()
        {
            Core.Renderer.Register(this);
        }
    }
}
