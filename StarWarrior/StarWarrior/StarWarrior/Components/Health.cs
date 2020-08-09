using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;

namespace StarWarrior.Components
{
    class Health : Component
    {

        public float MaxHealthValue { get; set; }

        public float HealthValue { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="health"></param>
        public Health(float health) : this(health, health)
        {
        
        }

        /// <summary>
        /// another constructor
        /// </summary>
        /// <param name="health"></param>
        /// <param name="maxHealth"></param>
        public  Health(float health, float maxHealth)
        {
            HealthValue = health;
            MaxHealthValue = maxHealth;
        }

        public float HealthStatus { get { return HealthValue/MaxHealthValue; } }

        public void AddDamage(float damage)
        {
            HealthValue -= damage;
            if (HealthValue < 0 )
                HealthValue = 0;
        }

        public bool IsAlive()
        {
            return HealthValue > 0;
        }

    }
}
