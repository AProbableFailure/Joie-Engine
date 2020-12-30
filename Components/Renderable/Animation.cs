using Joie.ECS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.Components
{
    public class Animation//Component : Component
    {
        //public Dictionary<uint, int> currentFrame = new Dictionary<uint, int>();
        //public Dictionary<uint, float> animationSpeed = new Dictionary<uint, float>();

        //public Dictionary<uint, int> frameCount = new Dictionary<uint, int>();
        //public Dictionary<uint, int> columns = new Dictionary<uint, int>();
        //public Dictionary<uint, int> rows = new Dictionary<uint, int>();
        //public Dictionary<uint, int> frameWidth = new Dictionary<uint, int>(); //{ get { return spriteSheet.Width / columns; } }
        //public Dictionary<uint, int> frameHeight = new Dictionary<uint, int>(); //{ get { return spriteSheet.Height / rows; } }
        //public Dictionary<uint, Vector2> frameSize = new Dictionary<uint, Vector2>(); //{ get { return new Vector2(frameWidth, frameHeight); } }

        //public Dictionary<uint, string> spriteSheetPath = new Dictionary<uint, string>();
        //public Dictionary<uint, Texture2D> spriteSheet = new Dictionary<uint, Texture2D>();

        //public Dictionary<uint, bool> isLooping = new Dictionary<uint, bool>();

        ////public Dictionary<uint, Func<bool>> trigger = new Dictionary<uint, Func<bool>>();

        //public override void HandleEntityAddition(uint entityID)
        //{
        //    Entities.Add(entityID);

        //    currentFrame.Add(entityID, 0);
        //    animationSpeed.Add(entityID, 1f);

        //    frameCount.Add(entityID, 0);
        //    columns.Add(entityID, 0);
        //    rows.Add(entityID, 0);
        //    frameWidth.Add(entityID, 0);
        //    frameHeight.Add(entityID, 0);
        //    frameSize.Add(entityID, Vector2.Zero);

        //    spriteSheetPath.Add(entityID, "");
        //    spriteSheet.Add(entityID, null);

        //    isLooping.Add(entityID, true);
        //}

        //public override void HandleEntityRemoval(uint entityID)
        //{
        //    Entities.Remove(entityID);

        //    currentFrame.Remove(entityID);
        //    animationSpeed.Remove(entityID);

        //    frameCount.Remove(entityID);
        //    columns.Remove(entityID);
        //    rows.Remove(entityID);
        //    frameWidth.Remove(entityID);
        //    frameHeight.Remove(entityID);
        //    frameSize.Remove(entityID);

        //    spriteSheetPath.Remove(entityID);
        //    spriteSheet.Remove(entityID);

        //    isLooping.Remove(entityID);
        //}

        //public void SetComponentProperties(uint entityID, string pSpriteSheetPath = "", int pColumns = 0, int pRows = 0, int pFrameCount = 0, float pAnimationSpeed = 0.2f, bool pIsLooping = true)
        //{
        //    animationSpeed[entityID] = pAnimationSpeed;

        //    frameCount[entityID] = pFrameCount;
        //    columns[entityID] = pColumns;
        //    rows[entityID] = pRows;

        //    spriteSheetPath[entityID] = pSpriteSheetPath;

        //    isLooping[entityID] = pIsLooping;

        //    UpdateComponentProperties(entityID);
        //}

        //public void UpdateComponentProperties(uint entityID)
        //{
        //    var _frameWidth = spriteSheet[entityID].Width / columns[entityID];
        //    var _frameHeight = spriteSheet[entityID].Height / rows[entityID];

        //    frameWidth[entityID] = _frameWidth;
        //    frameHeight[entityID] = _frameHeight;
        //    frameSize[entityID] = new Vector2(_frameWidth, _frameHeight);
        //}
        //public void LoadSpriteSheet(uint entityID, string pSpriteSheetPath, Microsoft.Xna.Framework.Content.ContentManager content)
        //{
        //    spriteSheet[entityID] = content.Load<Texture2D>(pSpriteSheetPath);
        //    UpdateComponentProperties(entityID);
        //}

        //public void LoadAllSpriteSheets(Microsoft.Xna.Framework.Content.ContentManager content)
        //{
        //    foreach (var entityID in Entities)
        //    {
        //        spriteSheet[entityID] = content.Load<Texture2D>(spriteSheetPath[entityID]);
        //        UpdateComponentProperties(entityID);
        //    }
        //}
        public string Name { get; set; }

        //public Func<bool> Trigger { get; set; }

        public int CurrentFrame { get; set; }
        public int FrameCount { get; private set; }
        public int Columns { get; private set; }
        public int Rows { get; private set; }
        public float AnimationSpeed { get; set; }

        public string SpriteSheetPath { get; private set; }
        public Texture2D SpriteSheet { get; private set; }
        public int FrameWidth { get { return SpriteSheet.Width / Columns; } }
        public int FrameHeight { get { return SpriteSheet.Height / Rows; } }
        public Vector2 FrameSize { get { return new Vector2(FrameWidth, FrameHeight); } }

        public bool IsLooping { get; set; } = true;

        public Animation(string pName, string pSpriteSheet, int pColumns, int pRows, int pFrameCount, float pAnimationSpeed = 0.2f)
        {
            Name = pName;

            //Trigger = pTrigger;

            AnimationSpeed = pAnimationSpeed;

            FrameCount = pFrameCount;

            Columns = pColumns;
            Rows = pRows;
            //IsLooping = true;

            SpriteSheetPath = pSpriteSheet;
        }

        public Animation(string pName, string pSpriteSheet, int pColumns, int pRows, float pAnimationSpeed = 0.2f)
        {
            Name = pName;

            //Trigger = pTrigger;

            AnimationSpeed = pAnimationSpeed;

            FrameCount = pColumns * pRows;

            Columns = pColumns;
            Rows = pRows;
            //IsLooping = true;

            SpriteSheetPath = pSpriteSheet;
        }

        public void LoadAnimationContent(ContentManager content)
        {
            SpriteSheet = content.Load<Texture2D>(SpriteSheetPath);
        }
    }
}
