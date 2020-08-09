﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ComponentPacMan.Core
{
    interface IPathProvider
    {
        IGrid Grid { get; }

        Queue<Vector2> FindPath(Vector2 begin, Vector2 end);
        
    }
}
