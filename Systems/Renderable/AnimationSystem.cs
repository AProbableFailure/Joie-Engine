using Joie.Components;
using Joie.ECS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.Ignore.Systems
{
    public class AnimationComponent//System : ECSSystem
    {
        public List<Animation> animations = new List<Animation>();
        public Animation currentAnimation;// = new Dictionary<uint, Animation>();
        public Dictionary<Func<bool>, Animation> animationTriggers = new Dictionary<Func<bool>, Animation>();
        //public Dictionary<uint, Dictionary<Func<bool>, Animation>> triggers = new Dictionary<uint, Dictionary<Func<bool>, Animation>>();
        public float timer = 0; // new Dictionary<uint, float>();

        public void AddAnimation(uint entityID, Animation animation, Func<bool> trigger)
        {
            //animations[entityID].Add(animation);
        }

        public void SetAnimation(uint entityID)
        {
            foreach (var trigger in animationTriggers.Keys)
            {
                if (trigger())
                {
                    Play(animationTriggers[trigger]);
                }
            }
        }

        public void Play(Animation animation)
        {
            //if 
        }
















        //public AnimationComponent animationComponent;

        //public Dictionary<uint, AnimationComponent> currentAnimation;
        ////public Dictionary<uint, List<(Func<bool>, string)> AnimationTriggers { get; set; } = new List<(Func<bool>, string)>();
        ////public Dictionary<string, AnimationComponent> EntityAnimations;
        //public Dictionary<uint, Dictionary<Func<bool>, AnimationComponent>> triggers;


        //public AnimationSystem(Scene scene)
        //{
        //    Scene = scene;
        //    animationComponent = scene.SceneGetOrAddComponent<AnimationComponent>();
        //}

        //public void AddAnimation(uint entityID, Func<bool> trigger)
        //{
        //    animationComponent
        //}

        //public override void InitializeSystem()
        //{

        //}

        //public override void LoadContentSystem(ContentManager content)
        //{
        //    animationComponent.LoadAllSpriteSheets(content);
        //    //foreach (var entityID in animationComponent.Entities)
        //    //{
        //    //    //animationComponent.spriteSheet[entityID] = content.Load<Texture2D>(animationComponent.spriteSheetPath[entityID]);
        //    //    //animationComponent.UpdateComponentProperties(entityID);
        //    //    animationComponent.LoadSpriteSheet(entityID, animationComponent.spriteSheetPath[entityID], content);
        //    //}
        //}

        //public override void UpdateSystem(GameTime gameTime)
        //{

        //}
        //public override void DrawSystem(SpriteBatch spriteBatch)
        //{

        //}
    }
}
