using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using Microsoft.Xna.Framework;
using StarWarrior.Components;

namespace StarWarrior.Spatials
{
    class Polygon
    {
        private readonly List<Vector2> _points;
        private bool _isClosed;
        private Vector2 _location;

        public Polygon()
        {
            _points = new List<Vector2>();
            _isClosed = false;
        }

        public void AddPoint(float x, float y)
        {
            _points.Add(new Vector2(x,y));
        }

        public void SetClosed(bool closed)
        {
            this._isClosed = closed;
        }

        public void SetLocation(float x, float y)
        {
            _location.X = x;
            _location.Y = y;
        }
    }

    
    class EnemyShip : Spatial
    {
        private Transform _transform;
        private Polygon _ship;

        public EnemyShip(EntityWorld world, Entity owner): base(world, owner)
        {
            
        }

        public new void Initialize() 
        {
		var transformMapper = new ComponentMapper<Transform>(World);
		_transform = transformMapper.Get(Owner);

		_ship = new Polygon();
		_ship.AddPoint(-10, -10);
		_ship.AddPoint(10, -10);
		_ship.AddPoint(0, 10);
		_ship.SetClosed(true);
	    }

	
	    public new void Render(GameTime gameTime) {
		    //g.setColor(Color.red);
		    //g.setAntiAlias(true);
		    _ship.SetLocation(_transform.LocationX(), _transform.LocationY());
		    //g.fill(ship);
	    }
    }
}
