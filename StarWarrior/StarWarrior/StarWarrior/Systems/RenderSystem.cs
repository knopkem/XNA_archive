using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;
using StarWarrior.Spatials;

namespace StarWarrior.Systems
{
    class RenderSystem : EntityProcessingSystem
    {
        //private Graphics graphics;
        private Bag<Spatial> spatials;
        private ComponentMapper<SpatialForm> spatialFormMapper;
        private ComponentMapper<Transform> transformMapper;
        private GameContainer container;

        public RenderSystem(GameContainer container)
            : base(typeof(Transform), typeof(SpatialForm))
        {
            this.container = container;
            //this.graphics = container.getGraphics();

            spatials = new Bag<Spatial>();
        }

        public override void Initialize()
        {
            spatialFormMapper = new ComponentMapper<SpatialForm>(world);
            transformMapper = new ComponentMapper<Transform>(world);
        }

        public override void Process(Entity e)
        {
            Spatial spatial = spatials.Get(e.GetId());
            Transform transform = transformMapper.Get(e);

            /*
            if (transform.LocationX() >= 0 && transform.LocationY() >= 0 && transform.LocationX() < container.GetWidth() && transform.LocationY() < container.GetHeight() && spatial != null)
            {
                spatial.Render(graphics);
            }
             * */
        }

        public override void Added(Entity e)
        {
            Spatial spatial = CreateSpatial(e);
            if (spatial != null)
            {
                spatial.Initialize();
                spatials.Set(e.GetId(), spatial);
            }
        }

        public override void Removed(Entity e)
        {
            spatials.Set(e.GetId(), null);
        }

        private Spatial CreateSpatial(Entity e)
        {
            SpatialForm spatialForm = spatialFormMapper.Get(e);
            String spatialFormFile = spatialForm.SpatialFormFile;

            if ("PlayerShip" == (spatialFormFile))
            {
                return new PlayerShip(world, e);
            }
            else if ("Missile" == (spatialFormFile))
            {
                return new Missile(world, e);
            }
            else if ("EnemyShip" == (spatialFormFile))
            {
                return new EnemyShip(world, e);
            }
            else if ("BulletExplosion" == (spatialFormFile))
            {
                return new Explosion(world, e, 10);
            }
            else if ("ShipExplosion" == (spatialFormFile))
            {
                return new Explosion(world, e, 30);
            }

            return null;
        }

    }
}
