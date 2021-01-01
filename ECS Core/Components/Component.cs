using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.ECS
{
    public abstract class Component //public class Component
    {
        //public List<uint> Entities = new List<uint>();
        public Entity Entity { get; set; }
        public bool Enabled { get; set; } = true;
        public bool Registered { get; set; }
        public virtual void OnAddComponent(Entity entity) => Entity = entity;

        public Component(bool registered)
        {
            Registered = registered;
            if (registered)
                RegisterComponent();
        }

        public abstract void RegisterComponent();
        //public abstract void HandleEntityAddition(uint entityID);
        //public abstract void HandleEntityRemoval(uint entityID);

        // create a method to set the values of properties in each component
    }
}
