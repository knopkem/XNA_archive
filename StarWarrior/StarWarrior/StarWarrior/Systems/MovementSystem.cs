using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using Microsoft.Xna.Framework;
using StarWarrior.Components;

namespace StarWarrior.Systems
{
    class MovementSystem : EntityProcessingSystem
    {
    private GameContainer container;
	private ComponentMapper<Velocity> velocityMapper;
	private ComponentMapper<Transform> transformMapper;

	public MovementSystem(GameContainer container) : base(typeof(Transform), typeof(Velocity)) 
    {
		this.container = container;
	}

	public override void Initialize() 
    {
		velocityMapper = new ComponentMapper<Velocity>(world);
		transformMapper = new ComponentMapper<Transform>(world);
	}

	public override void Process(Entity e)
    {
		Velocity velocity = velocityMapper.Get(e);
		float v = velocity.VelocityValue;

		Transform transform = transformMapper.Get(e);

		float r = velocity.AngleAsRadians();

		float xn = transform.LocationX() + (TrigLUT.Cos(r) * v * world.GetDelta());
		float yn = transform.LocationY() + (TrigLUT.Sin(r) * v * world.GetDelta());

		transform.Location = new Vector2(xn, yn);
	}

    }
}
