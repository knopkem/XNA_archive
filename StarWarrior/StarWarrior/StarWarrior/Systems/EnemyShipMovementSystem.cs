using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;

namespace StarWarrior.Systems
{
    /// <summary>
    /// WORKAROUND!!!
    /// </summary>
    class GameContainer
    {
        public float GetWidth()
        {
            return 1;
        }
    }

    class EnemyShipMovementSystem : EntityProcessingSystem
    {
        private GameContainer container;
        private ComponentMapper<Transform> transformMapper;
        private ComponentMapper<Velocity> velocityMapper;

        public EnemyShipMovementSystem(GameContainer container)
            : base(typeof(Transform), typeof(Enemy), typeof(Velocity))
        {
            this.container = container;
        }

        public override void Initialize()
        {
            transformMapper = new ComponentMapper<Transform>(world);
            velocityMapper = new ComponentMapper<Velocity>(world);
        }

        public override void Process(Entity e)
        {
            Transform transform = transformMapper.Get(e);
            Velocity velocity = velocityMapper.Get(e);

            if (transform.LocationX() > container.GetWidth() || transform.LocationX() < 0)
            {
                velocity.AddAngle(180);
            }
        }
    }
}
