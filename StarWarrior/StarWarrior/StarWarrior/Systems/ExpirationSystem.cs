using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;

namespace StarWarrior.Systems
{
    class ExpirationSystem : EntityProcessingSystem
    {
        private ComponentMapper<Expiration> expiresMapper;

	    public ExpirationSystem() : base(typeof(Expiration))
        {

	    }

	    public override void Initialize() {
		    expiresMapper = new ComponentMapper<Expiration>(world);
	    }

	    public override void Process(Entity e) 
        {
		    Expiration expires = expiresMapper.Get(e);
		    expires.ReduceLifeTime(world.GetDelta());

		    if (expires.IsExpired()) 
            {
			    world.DeleteEntity(e);
		    }

	    }

    }
}
