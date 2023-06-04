using System;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class HealCommand : ICommand
    {
        private readonly IHealth _health;
        private readonly int _heal;

        public HealCommand(IHealth health, int heal)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _heal = heal.ThrowIfLessThanOrEqualsToZeroException();
        }

        public void Execute()
        {
            _health.Heal(_heal);
        }
    }
}