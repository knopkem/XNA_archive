using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using Microsoft.Xna.Framework;

namespace StarWarrior.Spatials
{
    class Spatial
    {
        protected EntityWorld World;
        protected Entity Owner;

        public Spatial(EntityWorld world, Entity owner)
        {
            this.World = world;
            this.Owner = owner;
        }

        public virtual void Initialize()
        {
        }

        public virtual void Render(GameTime gameTime)
        {
            
        }

    }
}
