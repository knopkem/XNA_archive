using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using Microsoft.Xna.Framework;
using StarWarrior.Components;

namespace StarWarrior.Systems
{
    class HealthBarRenderSystem : EntityProcessingSystem
    {
    private GameContainer container;
	//private Graphics g;
	private ComponentMapper<Health> healthMapper;
	private ComponentMapper<Transform> transformMapper;

	public HealthBarRenderSystem(GameContainer container) : base (typeof(Health), typeof(Transform)) 
    {
		this.container = container;
		//this.g = container.GetGraphics();
	}

	public override void Initialize() {
		healthMapper = new ComponentMapper<Health>(world);
		transformMapper = new ComponentMapper<Transform>(world);
	}

	public override void Process(Entity e) 
    {
		Health health = healthMapper.Get(e);
		Transform transform = transformMapper.Get(e);
		
		//g.setColor(Color.white);
		//g.drawString(health.getHealthPercentage() + "%", transform.getX()-10, transform.getY()-30);
	}
    }
}
