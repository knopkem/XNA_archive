using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using Microsoft.Xna.Framework;
using StarWarrior.Components;

namespace StarWarrior.Spatials
{
    class Missile : Spatial
    {
        private Transform _transform;

        public Missile(EntityWorld world, Entity owner)
            : base(world, owner)
        {

        }

        public new void Initalize()
        {
            var transformMapper = new ComponentMapper<Transform>(World);
            _transform = transformMapper.Get(Owner);
        }

        public new void Render(GameTime gameTime)
        {
            //g.setColor(Color.white);
            //g.setAntiAlias(true);
            //g.fillRect(transform.getX() - 1, transform.getY() - 3, 2, 6);
        }
    }
    
}
