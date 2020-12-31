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
        //public string TextureName { get; set; }
        public Texture2D Texture { get; set; }
        public DivisionMethod Division { get; set; }
        public Vector2 SourceRectanglePosition { get; set; }
        public Vector2 SourceRectangleSize { get; set; }
        public Rectangle SourceRectangle { get => new Rectangle(SourceRectanglePosition.ToPoint(), SourceRectangleSize.ToPoint()); }//(SourceRectanglePosition.X, SourceRectangle.Y, (int)SourceRectangleSize.X, (int)SourceRectangleSize.Y); }

        public Texture2DComponent(string textureName, float xPos = 0, float yPos = 0, float xSize = 1, float ySize = 1, DivisionMethod division = DivisionMethod.Fractional)
        {
            //TextureName = textureName;
            Texture = Core.Renderer.SceneTextures[textureName];
            Division = division;

            SourceRectanglePosition = new Vector2(xPos, yPos);
            SourceRectangleSize = new Vector2(xSize, ySize);
        }

        public void Component_Draw(SpriteBatch spriteBatch)//, Texture2D texture)
        {
            var textureSize = new Vector2(Texture.Width, Texture.Height);
            spriteBatch.Draw(Texture
                            , new Vector2(100, 100)
                            , Division == DivisionMethod.ByPixel
                                ? SourceRectangle
                                : new Rectangle((textureSize * SourceRectanglePosition).ToPoint(), (textureSize * SourceRectangleSize).ToPoint())
                            , Color.White);
        }
    }
}
