using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;

namespace StarWarrior.Systems
{

    class CollisionSystem : EntitySystem
    {
        private ComponentMapper<Transform> _transformMapper;
        private ComponentMapper<Velocity> _velocityMapper;
        private ComponentMapper<Health> _healthMapper;

        public CollisionSystem()
        {
        }

        public new void Initialize()
        {
            _transformMapper = new ComponentMapper<Transform>(world);
            _velocityMapper = new ComponentMapper<Velocity>(world);
            _healthMapper = new ComponentMapper<Health>(world);
        }

        protected void ProcessEntities(Bag<Entity> entities)
        {
            Bag<Entity> bullets = world.GetGroupManager().getEntities("BULLETS");
            Bag<Entity> ships = world.GetGroupManager().getEntities("SHIPS");

            if (bullets != null && ships != null)
            {
                for (int a = 0; ships.Size() > a; a++)
                {
                    Entity ship = ships.Get(a);
                    for (int b = 0; bullets.Size() > b; b++)
                    {
                        Entity bullet = bullets.Get(b);

                        if (CollisionExists(bullet, ship))
                        {
                            Transform tb = _transformMapper.Get(bullet);
                            EntityFactory.CreateBulletExplosion(world, tb.LocationX(), tb.LocationY()).Refresh();
                            world.DeleteEntity(bullet);

                            Health health = _healthMapper.Get(ship);
                            health.AddDamage(4);


                            if (!health.IsAlive())
                            {
                                Transform ts = _transformMapper.Get(ship);

                                EntityFactory.CreateShipExplosion(world, ts.LocationX(), ts.LocationY()).Refresh();

                                world.DeleteEntity(ship);
                            }
                        }
                    }
                }
            }
        }

        private bool CollisionExists(Entity e1, Entity e2)
        {
            Transform t1 = _transformMapper.Get(e1);
            Transform t2 = _transformMapper.Get(e2);
            return t1.DistanceTo(t2) < 15;
        }

        protected new bool CheckProcessing()
        {
            return true;
        }
    }
    
}
