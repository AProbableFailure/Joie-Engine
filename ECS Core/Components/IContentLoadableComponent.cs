﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.ECS
{
    interface IContentLoadableComponent
    {
        void LoadContentComponent(Microsoft.Xna.Framework.Content.ContentManager content);
    }
}