using System;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class HealGood : IGood
    {
        private readonly IHealth _health;
        private readonly int _heal;

        public HealGood(IHealth health, int heal)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _heal = heal.ThrowIfLessThanOrEqualsToZeroException();
        }

        public void Buy()
        {
            _health.Heal(_heal);
        }
    }
}