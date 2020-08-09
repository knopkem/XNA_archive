using ComponentPacMan.Components;
using ComponentPacMan.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ComponentPacMan.Entities
{
    /// <summary>
    /// Build new entities using entity identifier
    /// </summary>
    static class EntityFactory
    {
        public static Entity CreateEntityInstance(EntityType type, ContentManager content, Vector2 position)
        {
            var direction = new Vector2(0, 0);
            float speed =60f;
            Entity newEntity = null;
            switch (type)
            {
                case EntityType.Ghost:
                    newEntity = new Entity(type);
                    newEntity.AddComponent(new PositionComponent(position));
                    newEntity.AddComponent(new MovementComponent(direction, speed));
                    
                    // ghost base
                    SpriteComponent ghostBaseSprite = CreateSprite(ResourceMapper.SpriteName(ESprites.GhostBase), content);
                    ghostBaseSprite.SpriteColor = Color.Red;
                    Point size = ghostBaseSprite.SpriteSize;
                    
                    // ghost eyes                    
                    var ghostEyesSprite = CreateSprite(ResourceMapper.SpriteName(ESprites.GhostEyes), content);
                    ghostEyesSprite.RelativePosition= new Vector2(4, 6);
                    
                    // ghost center                    
                    var ghostCenterSprite = CreateSprite(ResourceMapper.SpriteName(ESprites.GhostEyesCenter), content);
                    ghostCenterSprite.RelativePosition = new Vector2(6, 8);
                    
                    // assemble textures in the correct order
                    var ghostAssembly = new SpriteCompositionComponent();
                    ghostAssembly.AddSprite(ghostBaseSprite);
                    ghostAssembly.AddSprite(ghostEyesSprite);
                    ghostAssembly.AddSprite(ghostCenterSprite);
                    ghostAssembly.RelativePosition = new Vector2(-5, -5);

                    newEntity.AddComponent(ghostAssembly);
                    newEntity.AddComponent(new CollisionComponent(new Rectangle((int)position.X, (int)position.Y, size.X, size.Y)));
                    var pathComp = new PathComponent {Target = position};
                    newEntity.AddComponent(pathComp);
                    break;

                case EntityType.Player:
                    newEntity = new Entity(type);
                    newEntity.AddComponent(new PositionComponent(position));
                    newEntity.AddComponent(new MovementComponent(direction, speed));
                    
                    var playerSprite = CreateSprite(ResourceMapper.SpriteName(ESprites.PacManEating1), content);
                    playerSprite.RelativePosition = new Vector2(5, 5);
                    newEntity.AddComponent(playerSprite);

                    break;

                case EntityType.Board:
                    newEntity = new Entity(type);
                    newEntity.AddComponent(new PositionComponent(position));
                    
                    var grid = new RandomGrid();
                    var gridComponent = new GridComponent(grid);
                    newEntity.AddComponent(gridComponent);
                    
                    var boardSprite = CreateSprite(ResourceMapper.SpriteName(ESprites.Board), content);
                    newEntity.AddComponent(boardSprite);
                    break;

                case EntityType.Crump:
                    newEntity = new Entity(type);
                    newEntity.AddComponent(new PositionComponent(position));

                    var crumpSprite = CreateSprite(ResourceMapper.SpriteName(ESprites.Crump), content);
                    crumpSprite.RelativePosition = new Vector2(5, 5);
                    newEntity.AddComponent(crumpSprite);
                    break;
            }

            return newEntity;
        }

        private static SpriteComponent CreateSprite(string textureName, ContentManager content)
        {
            var texture = content.Load<Texture2D>(textureName);
            return new SpriteComponent(texture);
        }
    }
}
