using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using Microsoft.Xna.Framework;
using StarWarrior.Components;

namespace StarWarrior.Systems
{
    class EnemySpawnSystem : IntervalEntitySystem
    {
        private ComponentMapper<Weapon> weaponMapper;
	    private long now;
	    private ComponentMapper<Transform> transformMapper;
	    private GameContainer container;
	    private Random r;

	    public EnemySpawnSystem(int interval, GameContainer container) : base(interval, typeof(Transform), typeof(Weapon), typeof(Enemy)) 
        {
		    this.container = container;
	    }

	    public override void Initialize() 
        {
		    weaponMapper = new ComponentMapper<Weapon>(world);
		    transformMapper = new ComponentMapper<Transform>(world);
		
		    r = new Random();
	    }
	
            // override??
	    protected void ProcessEntities(Bag<Entity> entities) 
        {
		    Entity e = EntityFactory.CreateEnemyShip(world);
		
		    e.GetComponent<Transform>().Location = new Vector2(r.Next((int)container.GetWidth()), r.Next(400)+50);
		    e.GetComponent<Velocity>().VelocityValue = 0.05f;
		    //e.GetComponent<Velocity>().Angle = (r.nextBoolean() ? 0 : 180);
	        e.GetComponent<Velocity>().Angle = 180;
		    e.Refresh();
	    }
    }
}
