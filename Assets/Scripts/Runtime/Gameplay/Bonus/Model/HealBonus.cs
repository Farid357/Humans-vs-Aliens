using System;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class HealBonus : IBonus
    {
        private readonly IBonus _bonus;
        private readonly IHealth _health;
        private readonly int _heal;

        public HealBonus(IBonus bonus, IHealth health, int heal)
        {
            _bonus = bonus ?? throw new ArgumentNullException(nameof(bonus));
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _heal = heal.ThrowIfLessThanOrEqualsToZeroException();
        }

        public void PickUp()
        {
            _bonus.PickUp();
            _health.Heal(_heal);
        }
    }
}