using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using Microsoft.Xna.Framework;

namespace StarWarrior.Components
{
    class Transform : Component
    {
        private Vector2 _location;
        public Vector2 Location { get { return _location; } set { _location = value; } }

        public float Rotation { get; set; }

        public Transform()
        {
        }

        public Transform(float x, float y) : this(new Vector2(x,y))
        {
            
        }

        public Transform(Vector2 location)
        {
            this.Location = location;
        }

        public Transform(Vector2 location, float rotation)
        {
            this.Location = location;
            this.Rotation = rotation;
        }

        public void AddX(float x)
        {
            this._location.X += x;
        }

        public void AddY(float y)
        {
            this._location.Y += y;
        }

        public float LocationX()
        {
            return _location.X;
        }

        public void SetX(float x)
        {
            this._location.X = x;
        }

        public float LocationY()
        {
            return _location.Y;
        }

        public void SetY(float y)
        {
            this._location.Y = y;
        }
        
        public void AddRotation(float angle)
        {
            Rotation = (Rotation + angle) % 360;
        }

        public float RotationAsRadians()
        {
            return (float)MathHelper.ToRadians(Rotation);
        }

        public float DistanceTo(Transform t)
        {
            return Utils.Distance(t.LocationX(), t.LocationY(), this.Location.X, this.Location.Y);
        }
    }
}
