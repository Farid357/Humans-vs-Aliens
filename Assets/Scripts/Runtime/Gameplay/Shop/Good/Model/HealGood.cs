using System;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class HealGood : IGood
    {
        private readonly IGood _good;
        private readonly IHealth _health;
        private readonly int _heal;

        public HealGood(IGood good, IHealth health, int heal)
        {
            _good = good ?? throw new ArgumentNullException(nameof(good));
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _heal = heal.ThrowIfLessThanOrEqualsToZeroException();
        }

        public bool IsBought => _good.IsBought;
 
        public IGoodData Data => _good.Data;

        public void Buy()
        {
            _health.Heal(_heal);
            _good.Buy();
        }
    }
}