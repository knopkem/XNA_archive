using ComponentPacMan.Components;
using ComponentPacMan.Core;
using ComponentPacMan.Entities;
using ComponentPacMan.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ComponentPacMan
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class PacMan : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // systems
        private MovementSystem _movementSystem;
        private RenderSystem _renderSystem;
        private CollisionWarningSystem _collWarnSystem;
        private PathFindingSystem _pathFindSystem;
        private WaypointingSystem _wayPointSystem;
        private PlayerControlSystem _playerControlSystem;

        // other
        private PathProvider _pathProvider;
        private IGrid _grid;

        public PacMan()
        {
            _graphics = new GraphicsDeviceManager(this)
                            {
                                PreferredBackBufferWidth = 720,
                                PreferredBackBufferHeight = 640
                            };
            Content.RootDirectory = "Content";


            // create systems
            _movementSystem = new MovementSystem();
            _renderSystem = new RenderSystem();
            _collWarnSystem = new CollisionWarningSystem();
            _pathFindSystem = new PathFindingSystem();
            _wayPointSystem = new WaypointingSystem();
            _playerControlSystem = new PlayerControlSystem();
  
        }

        private void InitializeGrid()
        {
            var boardInstance = EntityFactory.CreateEntityInstance(EntityType.Board, Content, new Vector2(0, 0));
            if (boardInstance == null)
                return;

            _renderSystem.RegisterEntity(boardInstance);
            var gridComponent = boardInstance.GetComponent(ComponentType.Grid) as GridComponent;
            if (gridComponent != null)
            {
                _grid = gridComponent.GridInstance;
                _pathProvider = new PathProvider(_grid);
                _pathFindSystem.PathProvider = _pathProvider;

            }
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            SystemManager.RegisterSystem(_movementSystem);
            SystemManager.RegisterSystem(_renderSystem);
            SystemManager.RegisterSystem(_collWarnSystem);
            SystemManager.RegisterSystem(_pathFindSystem);
            SystemManager.RegisterSystem(_wayPointSystem);
            SystemManager.RegisterSystem(_playerControlSystem);
  
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Create Game Objects
            InitializeGrid();
            FillCrumps();
            SpawnGhosts();
            SpawnPlayer();
            
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
                Exit();

            SystemManager.Update(gameTime);
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            SystemManager.Draw(gameTime, _spriteBatch);

            base.Draw(gameTime);
        }

        private void SpawnPlayer()
        {
            var spawnPoint = Algorithms.Grid2World(new Point(1, 1), _grid.TileSize);

            var playerInstance = EntityFactory.CreateEntityInstance(EntityType.Player, Content, spawnPoint);
        
            // register entity in systems
            _movementSystem.RegisterEntity(playerInstance);
            _renderSystem.RegisterEntity(playerInstance);
            _collWarnSystem.RegisterEntity(playerInstance);
            _playerControlSystem.RegisterEntity(playerInstance);
        }

        private void SpawnGhosts()
        {
            for (int i = 0; i < 10; i++)
            {
                var spawnPoint = Algorithms.Grid2World(new Point(13,11), _grid.TileSize);

                var ghostInstance = EntityFactory.CreateEntityInstance(EntityType.Ghost, Content, spawnPoint);

                // register entity in systems
                _movementSystem.RegisterEntity(ghostInstance);
                _renderSystem.RegisterEntity(ghostInstance);
                _pathFindSystem.RegisterEntity(ghostInstance);
                _wayPointSystem.RegisterEntity(ghostInstance);
            }
        }

        private void FillCrumps()
        {
  
            if(_grid != null)
            {
                for(int j = 0; j < _grid.Height; j++)
                    for(int i=0; i < _grid.Width; i++)
                    {
                        if (_grid.TileGrid[i, j].HasCrump)
                        {
                            var pos = new Vector2((i * _grid.TileSize), (j * _grid.TileSize));
                            var crump = EntityFactory.CreateEntityInstance(EntityType.Crump, Content, pos);
                            _renderSystem.RegisterEntity(crump);
                        }
                    }

            }
            
        }
    }
}
