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

        public bool CanBePicked => _bonus.CanBePicked && _health.Value < 100;

        public void PickUp()
        {
            if (!CanBePicked)
                throw new InvalidOperationException($"Bonus can't be picked! Health value is greater than 100!");

            _bonus.PickUp();
            _health.Heal(_heal);
        }
    }
}