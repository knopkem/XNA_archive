using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using Microsoft.Xna.Framework;
using StarWarrior.Components;

namespace StarWarrior.Systems
{
    class PlayerShipControlSystem : EntityProcessingSystem
    {
        private GameContainer container;
        private bool moveRight;
        private bool moveLeft;
        private bool shoot;
        private ComponentMapper<Transform> transformMapper;

        public PlayerShipControlSystem(GameContainer container)
            : base(typeof(Transform), typeof(Player))
        {
            this.container = container;
        }

        public override void Initialize()
        {
            transformMapper = new ComponentMapper<Transform>(world);
            //container.getInput().addKeyListener(this);
        }

        public override void Process(Entity e)
        {
            Transform transform = transformMapper.Get(e);

            if (moveLeft)
            {
                transform.AddX(world.GetDelta() * -0.3f);
            }
            if (moveRight)
            {
                transform.AddX(world.GetDelta() * 0.3f);
            }

            if (shoot)
            {
                Entity missile = EntityFactory.CreateMissile(world);
                missile.GetComponent<Transform>().Location = new Vector2(transform.LocationX(), transform.LocationY() - 20);
                missile.GetComponent<Velocity>().VelocityValue = (-0.5f);
                missile.GetComponent<Velocity>().Angle = (90);
                missile.Refresh();

                shoot = false;
            }
        }
        /*
        public void KeyPressed(int key, char c)
        {
            if (key == Input.KEY_A)
            {
                moveLeft = true;
                moveRight = false;
            }
            else if (key == Input.KEY_D)
            {
                moveRight = true;
                moveLeft = false;
            }
            else if (key == Input.KEY_SPACE)
            {
                shoot = true;
            }
        }

        public void keyReleased(int key, char c)
        {
            if (key == Input.KEY_A)
            {
                moveLeft = false;
            }
            else if (key == Input.KEY_D)
            {
                moveRight = false;
            }
            else if (key == Input.KEY_SPACE)
            {
                shoot = false;
            }
        }
        */

        public bool IsAcceptingInput()
        {
            return true;
        }
    }

}
