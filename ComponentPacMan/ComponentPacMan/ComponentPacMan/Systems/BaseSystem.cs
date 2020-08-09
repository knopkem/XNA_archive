using System.Collections.Generic;
using ComponentPacMan.Components;
using ComponentPacMan.Entities;

namespace ComponentPacMan.Systems
{
    interface ISystem
    {
    }

    class BaseSystem : ISystem
    {
        protected readonly List<IEntity> Entities = new List<IEntity>();

        public void RegisterEntity(IEntity entity)
        {
            Entities.Add(entity);
        }

        protected bool IsComponentNull(IComponent component)
        {
            return component == null;
        }
    }
}
