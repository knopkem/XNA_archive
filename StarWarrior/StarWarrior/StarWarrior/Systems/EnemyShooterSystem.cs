using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using Microsoft.Xna.Framework;
using StarWarrior.Components;

namespace StarWarrior.Systems
{
    class EnemyShooterSystem : EntityProcessingSystem
    {
        
	    private ComponentMapper<Weapon> weaponMapper;
	    private long now;
	    private ComponentMapper<Transform> transformMapper;

        public EnemyShooterSystem() : base(typeof(Transform), typeof(Weapon), typeof(Enemy))
        {
		
	    }

	    public override void Initialize() {
		    weaponMapper = new ComponentMapper<Weapon>(world);
		    transformMapper = new ComponentMapper<Transform>(world);
	    }

	    protected override void Begin() {
		    //now = System.currentTimeMillis();
	    }

	    public override void Process(Entity e) {
		    Weapon weapon = weaponMapper.Get(e);

		    if (weapon.ShootAt + 2000 < now) {
			    Transform transform = transformMapper.Get(e);

			    Entity missile = EntityFactory.CreateMissile(world);
			    missile.GetComponent<Transform>().Location = new Vector2(transform.LocationX(), transform.LocationY() + 20);
			    missile.GetComponent<Velocity>().VelocityValue = -0.5f;
			    missile.GetComponent<Velocity>().Angle = 270;
			    missile.Refresh();

			    weapon.ShootAt = now;
		    }

	    }
    }
}
