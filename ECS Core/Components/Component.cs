using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.ECS
{
    public class Component
    {
        public List<uint> Entities = new List<uint>();
        public bool Enabled { get; set; } = true;

        // in implementation, add the entityID to each property and give them default implementations
        public virtual void HandleEntityAddition(uint entityID)
            => Entities.Add(entityID);
        public virtual void HandleEntityRemoval(uint entityID)
            => Entities.Remove(entityID);

        // create a method to set the values of properties in each component
    }
}
