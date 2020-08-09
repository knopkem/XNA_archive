using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Artemis;

namespace StarWarrior.Components
{
    class Expiration : Component
    {
        private readonly int _initialLifeTime;

        public int LifeTime { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lifeTime"></param>
        public Expiration(int lifeTime)
        {
            _initialLifeTime = LifeTime = lifeTime;
        }

        public float LifeTimePercentage { get { return (float) LifeTime/(float) _initialLifeTime; } }

        public void ReduceLifeTime(int reduction)
        {
            LifeTime -= reduction;
        }

        public bool IsExpired()
        {
            return LifeTime <= 0;
        }
    }
}
