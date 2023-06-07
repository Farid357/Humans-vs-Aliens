using System;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class HealCheat : ICheat
    {
        private readonly IHealth _health;
        private readonly int _heal;

        public HealCheat(IHealth health, int heal)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _heal = heal.ThrowIfLessThanOrEqualsToZeroException();
        }

        public void Activate()
        {
            _health.Heal(_heal);
        }
    }
}