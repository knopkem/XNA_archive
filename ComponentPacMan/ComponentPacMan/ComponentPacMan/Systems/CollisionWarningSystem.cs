﻿using System.Collections.Generic;
using ComponentPacMan.Components;
using ComponentPacMan.Entities;
using Microsoft.Xna.Framework;

namespace ComponentPacMan.Systems
{
    /// <summary>
    /// Uses CollisionComponents to check for possible collisions of movable objects with static ones
    /// The Compared
    /// </summary>
    class CollisionWarningSystem : BaseSystem, IUpdateable
    {

        public void Update(GameTime gameTime)
        {
            var movableObj = new List<IEntity>();
            var staticObj = new List<IEntity>();

            // get all static object
            foreach (var entity in Entities)
            {
                var pos = entity.GetComponent(ComponentType.Position);
                var col = entity.GetComponent(ComponentType.Collison);
                var mov = entity.GetComponent(ComponentType.Movement);
                
                if (!IsComponentNull(pos) && !IsComponentNull(col))
                {
                    if (!IsComponentNull(mov))
                        movableObj.Add(entity);
                    else
                        staticObj.Add(entity);
                }
            }

            // cycle all entities and check for collision components
            foreach (var movable in movableObj)
            {
                // check against statics
            }
        }
    }
}
