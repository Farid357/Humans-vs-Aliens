using System;

namespace HumansVsAliens.Gameplay
{
    public class AbilityGood : IGood
    {
        private readonly IAbility _ability;
        private readonly IGood _good;

        public AbilityGood(IGood good, IAbility ability)
        {
            _good = good ?? throw new ArgumentNullException(nameof(good));
            _ability = ability ?? throw new ArgumentNullException(nameof(ability));
        }

        public IGoodData Data => _good.Data;

        public bool IsBought => _good.IsBought;

        public void Buy()
        {
            if (_ability.IsActive)
                return;

            _ability.Activate();
            _good.Buy();
        }
    }
}