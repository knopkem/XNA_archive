using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ComponentPacMan.Core;

namespace ComponentPacManTest
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class ResourceTestComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SpriteBatch _spriteBatch = null;
        private GraphicsDeviceManager _graphics = null;
        private bool IsInitialized { get; set; }

        private List<Texture2D> _textureList = new List<Texture2D>();

        public ResourceTestComponent(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
            IsInitialized = false;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            _spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            _graphics = (GraphicsDeviceManager)Game.Services.GetService(typeof(GraphicsDeviceManager));

            if (_spriteBatch == null || _graphics == null)
                return;


            IsInitialized = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // load all textures
            foreach (ESprites value in Enum.GetValues(typeof(ESprites)))
            {
                string resourceName = ResourceMapper.SpriteName(value);
                Texture2D myTexture = Game.Content.Load<Texture2D>(resourceName);
                _textureList.Add(myTexture);
            }

            foreach (EBonusSprites value in Enum.GetValues(typeof(EBonusSprites)))
            {
                string resourceName = ResourceMapper.BonusSpriteName(value);
                Texture2D myTexture = Game.Content.Load<Texture2D>(resourceName);
                _textureList.Add(myTexture);
            }

            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {            
            if (!IsInitialized)
                return;


            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (!IsInitialized)
                return;
            
            _spriteBatch.Begin();

            foreach (Texture2D texture in _textureList)
            {
                var target = new Rectangle(0, 0, texture.Width, texture.Height);
                _spriteBatch.Draw(texture, target, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
