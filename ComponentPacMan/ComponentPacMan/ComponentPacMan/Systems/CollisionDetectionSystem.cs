﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComponentPacMan.Components;
using ComponentPacMan.Entities;
using Microsoft.Xna.Framework;

namespace ComponentPacMan.Systems
{
    /// <summary>
    /// Checking collisions happening just now
    /// </summary>
    class CollisionDetectionSystem : BaseSystem , IUpdateable
    {
 
        public void Update(GameTime gameTime)
        {
            var movableObj = new List<CollisionComponent>();
            CollisionComponent player = null;

            // get all object that have collision 
            foreach (var entity in Entities)
            {
                
                var col = entity.GetComponent(ComponentType.Collision) as CollisionComponent;
                var mov = entity.GetComponent(ComponentType.Movement);

                if (IsComponentNull(col) || IsComponentNull(mov))
                    continue;

                // get the player
                if (entity.EntityType() == EntityType.Player)
                {
                    player = col;
                    continue;
                }

                movableObj.Add(col);
                
            }

            // no player found, nothing to check
            if (player == null)
                return;

            // check player collision against movable objects
            foreach (var checkAgainsCol in movableObj)
            {

                if (player.CollisionFrame.Intersects(checkAgainsCol.CollisionFrame))
                    player.HasCollided = true;
            }
            
 

        }


    }
}
