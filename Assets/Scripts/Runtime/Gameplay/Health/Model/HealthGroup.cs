using System;
using System.Collections.Generic;
using System.Linq;

namespace HumansVsAliens.Gameplay
{
    public class HealthGroup : IHealth
    {
        private readonly IReadOnlyList<IHealth> _all;

        public HealthGroup(IReadOnlyList<IHealth> all)
        {
            if (all.Count == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(all));

            _all = all;
        }

        public bool IsAlive => _all.Any(health => health.IsAlive);

        public int Value => _all.Sum(health => health.Value);

        public void TakeDamage(int damage)
        {
            if (!IsAlive)
                throw new InvalidOperationException($"Health isn't alive!");
            
            foreach (IHealth health in _all)
            {
                if (health.IsAlive)
                    health.TakeDamage(damage);
            }
        }

        public void Heal(int heal)
        {
            foreach (IHealth health in _all)
            {
                health.Heal(heal);
            }
        }
    }
}