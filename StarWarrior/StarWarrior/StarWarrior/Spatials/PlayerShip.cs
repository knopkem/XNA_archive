using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using Microsoft.Xna.Framework;
using StarWarrior.Components;

namespace StarWarrior.Spatials
{
    class PlayerShip : Spatial
    {

        private Transform _transform;
        private Polygon _ship;

        public PlayerShip(EntityWorld world, Entity owner)
            : base(world, owner)
        {
        }

        public new void Initalize()
        {
            var transformMapper = new ComponentMapper<Transform>(World);
            _transform = transformMapper.Get(Owner);

            _ship = new Polygon();
            _ship.AddPoint(0, -10);
            _ship.AddPoint(10, 10);
            _ship.AddPoint(-10, 10);
            _ship.SetClosed(true);
        }

        public new void Render(GameTime gameTime)
        {
            //g.setColor(Color.white);
            //g.setAntiAlias(true);
            //ship.setLocation(transform.getX(), transform.getY());
            //g.fill(ship);
        }
    }
    
}
