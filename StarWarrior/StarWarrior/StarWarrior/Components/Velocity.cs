using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using Microsoft.Xna.Framework;

namespace StarWarrior.Components
{
    class Velocity : Component
    {

        public float VelocityValue { get; set; }

        public float Angle { get; set; }

        public void AddVelocity( float velocity)
        {
            VelocityValue += velocity;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Velocity()
        {
            
        }

        public Velocity(float vector)
        {
            this.VelocityValue = vector;
        }

        public Velocity(float velocity, float angle)
        {
            this.VelocityValue = velocity;
            this.Angle = angle;
        }

        public void AddAngle(float a)
        {
            Angle = (Angle + a) % 360;
        }

        public float AngleAsRadians()
        {
            return (float)MathHelper.ToRadians(Angle);
        }
    }
}
