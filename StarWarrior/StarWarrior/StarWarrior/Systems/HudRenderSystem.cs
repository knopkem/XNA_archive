using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using Microsoft.Xna.Framework;
using StarWarrior.Components;

namespace StarWarrior.Systems
{
    class HudRenderSystem : EntityProcessingSystem
    {
    private GameContainer container;
	//private Graphics g;
	private ComponentMapper<Health> healthMapper;

	public HudRenderSystem(GameContainer container) : base(typeof(Health), typeof(Player)) 
    {
		this.container = container;
		//this.g = container.getGraphics();
	}

	public override void Initialize() {
		healthMapper = new ComponentMapper<Health>(world);
	}

	public override void Process(Entity e) {
		Health health = healthMapper.Get(e);
		//g.setColor(Color.white);
		//g.drawString("Health: " + health.getHealthPercentage() + "%", 20, container.getHeight() - 40);
	}

    }
}
