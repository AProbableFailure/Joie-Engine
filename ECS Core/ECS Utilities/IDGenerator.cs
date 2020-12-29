using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.ECS.Utilities
{
    public static class IDGenerator
    {
        private static uint _id = 0;
        public static uint ID
        {
            get => ++_id;
        }
    }
}
