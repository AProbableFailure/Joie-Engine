using Joie.ECS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.Components
{
    public enum DivisionMethod
    {
        ByPixel,
        Fractional
    }
    public class Texture2DComponent : Component
    {
        public Texture2D Texture { get; set; }
        public Vector2 TextureSize { get => new Vector2(Texture.Width, Texture.Height); }
        public DivisionMethod Division { get; set; }
        private Vector2 _sourceRectanglePosition;
        public Vector2 SourceRectanglePosition 
        { 
            get
            {
                return Division == DivisionMethod.ByPixel
                    ? _sourceRectanglePosition
                    : TextureSize * _sourceRectanglePosition;
            }
            set => _sourceRectanglePosition = value;
        }
        private Vector2 _sourceRectangleSize;
        public Vector2 SourceRectangleSize
        {
            get
            {
                return Division == DivisionMethod.ByPixel
                    ? _sourceRectangleSize
                    : TextureSize * _sourceRectangleSize;
            }
            set => _sourceRectangleSize = value;
        }
        public Rectangle SourceRectangle 
        {
            get
            {
                return new Rectangle(SourceRectanglePosition.ToPoint(), SourceRectangleSize.ToPoint());
                //var textureSize = new Vector2(Texture.Width, Texture.Height);
                //return Division == DivisionMethod.ByPixel
                //    ? new Rectangle(SourceRectanglePosition.ToPoint(), SourceRectangleSize.ToPoint())
                //    : new Rectangle((TextureSize * SourceRectanglePosition).ToPoint(), (TextureSize * SourceRectangleSize).ToPoint());
            }
        }
        
        //(SourceRectanglePosition.X, SourceRectangle.Y, (int)SourceRectangleSize.X, (int)SourceRectangleSize.Y); }

        public Texture2DComponent(string textureName, float xPos = 0, float yPos = 0, float xSize = 1, float ySize = 1, DivisionMethod division = DivisionMethod.Fractional)
        {
            //TextureName = textureName;
            Texture = Core.Renderer.SceneTextures[textureName];
            Division = division;

            SourceRectanglePosition = new Vector2(xPos, yPos);
            SourceRectangleSize = new Vector2(xSize, ySize);

            Console.WriteLine(SourceRectangleSize);
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
    }
}
