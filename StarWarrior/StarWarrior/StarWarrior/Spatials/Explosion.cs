using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using Microsoft.Xna.Framework;
using StarWarrior.Components;

namespace StarWarrior.Spatials
{
    class Explosion : Spatial
    {
        
	private Transform _transform;
	private Expiration _expires;
	private int _initialLifeTime;
	private Color _color;
	private int _radius;

	public Explosion(EntityWorld world, Entity owner, int radius) : base(world, owner)
    {
		this._radius = radius; 
	}

	public new void Initalize() {
		var transformMapper = new ComponentMapper<Transform>(World);
		_transform = transformMapper.Get(Owner);
		
		var expiresMapper = new ComponentMapper<Expiration>(World);
		_expires = expiresMapper.Get(Owner);
		_initialLifeTime = _expires.LifeTime;
		
		_color = new Color(255,255,0);
	}

	public new void Render(GameTime gameTime) {
		
		//_color.A = (float)_expires.LifeTime/(float)_initialLifeTime;
		
		//g.setColor(color);
		//g.setAntiAlias(true);
		//g.fillOval(transform.getX() - radius, transform.getY() - radius, radius*2, radius*2);
	}

    }
}
