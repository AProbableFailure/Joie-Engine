using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.ECS
{
    public class Component
    {
        public Entity ParentEntity { get; set; }
        public bool Enabled { get; set; } = true;

        // We're setting the entity on_add instead of on construction so that 
        // you don't need to pass an entity every construction
        public virtual void OnAddComponent(Entity parentEntity) => ParentEntity = parentEntity;
    }
}
