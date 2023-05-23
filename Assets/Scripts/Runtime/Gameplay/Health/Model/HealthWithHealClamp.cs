using System;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public sealed class HealthWithHealClamp : IHealth
    {
        private readonly IHealth _health;
        private readonly int _maxPossibleValue;

        public HealthWithHealClamp(IHealth health, int maxPossibleValue)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _maxPossibleValue = maxPossibleValue.ThrowIfLessThanOrEqualsToZeroException();
        }

        public HealthWithHealClamp(IHealth health) : this(health, health.Value)
        {
        }

        public bool IsAlive => _health.IsAlive;

        public int Value => _health.Value;

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }

        public void Heal(int heal)
        {
            if (_health.Value + heal > _maxPossibleValue)
                heal = _maxPossibleValue - _health.Value;

            _health.Heal(heal);
        }
    }
}