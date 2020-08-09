using System;
using System.Collections.Generic;
using System.Linq;
using Artemis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using StarWarrior.Components;
using StarWarrior.Systems;

namespace StarWarrior
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class StarWarrior : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private EntityWorld world;
        private GameContainer container;

        private EntitySystem renderSystem;
        private EntitySystem hudRenderSystem;
        private EntitySystem controlSystem;
        private EntitySystem movementSystem;
        private EntitySystem enemyShooterSystem;
        private EntitySystem enemyShipMovementSystem;
        private EntitySystem collisionSystem;
        private EntitySystem healthBarRenderSystem;
        private EntitySystem enemySpawnSystem;
        private EntitySystem expirationSystem;

        public StarWarrior()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            world = new EntityWorld();

            SystemManager systemManager = world.GetSystemManager();
            renderSystem = systemManager.SetSystem(new RenderSystem(container));
            hudRenderSystem = systemManager.SetSystem(new HudRenderSystem(container));
            controlSystem = systemManager.SetSystem(new MovementSystem(container));
            movementSystem = systemManager.SetSystem(new PlayerShipControlSystem(container));
            enemyShooterSystem = systemManager.SetSystem(new EnemyShipMovementSystem(container));
            enemyShipMovementSystem = systemManager.SetSystem(new EnemyShooterSystem());
            collisionSystem = systemManager.SetSystem(new CollisionSystem());
            healthBarRenderSystem = systemManager.SetSystem(new HealthBarRenderSystem(container));
            enemySpawnSystem = systemManager.SetSystem(new EnemySpawnSystem(500, container));
            expirationSystem = systemManager.SetSystem(new ExpirationSystem());

            systemManager.InitializeAll();

            InitPlayerShip();
            InitEnemyShips();


            base.Initialize();
        }

        private void InitEnemyShips()
        {
            Random r = new Random();
            for (int i = 0; 10 > i; i++)
            {
                Entity e = EntityFactory.CreateEnemyShip(world);

                //e.GetComponent<Transform>().Location = new Vector2(r.Next(container.getWidth()), r.nextInt(400)+50);
                e.GetComponent<Velocity>().VelocityValue = (0.05f);
                e.GetComponent<Velocity>().Angle = (180);

                e.Refresh();
            }
        }

        private void InitPlayerShip() 
        {
		    Entity e = world.CreateEntity();
		    e.SetGroup("SHIPS");
		    //e.AddComponent(new Transform(container.GetWidth() / 2, container.GetHeight() - 40));
		    e.AddComponent(new SpatialForm("PlayerShip"));
		    e.AddComponent(new Health(30));
		    e.AddComponent(new Player());
		
		    e.Refresh();
	    }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            world.LoopStart();

            world.SetDelta(gameTime.ElapsedGameTime.Milliseconds);

            controlSystem.Process();
            movementSystem.Process();
            enemyShooterSystem.Process();
            enemyShipMovementSystem.Process();
            collisionSystem.Process();
            enemySpawnSystem.Process();
            expirationSystem.Process();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            renderSystem.Process();
            healthBarRenderSystem.Process();
            hudRenderSystem.Process();

            base.Draw(gameTime);
        }
    }
}
