using System;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public sealed class Health : IHealth
    {
        public Health(int value)
        {
            Value = value.ThrowIfLessThanOrEqualsToZeroException();
        }

        public int Value { get; private set; }

        public bool IsAlive => Value > 0;

        public void TakeDamage(int damage)
        {
            if (!IsAlive)
                throw new InvalidOperationException($"Health isn't alive!");

            Value = Math.Max(0, Value - damage.ThrowIfLessThanZeroException());
        }

        public void Heal(int heal)
        {
            Value += heal.ThrowIfLessThanZeroException();
        }
    }
}