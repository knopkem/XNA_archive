using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ComponentPacMan.Entities
{
    internal interface IRenderable
    {
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}