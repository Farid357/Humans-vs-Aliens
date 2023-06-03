using System;

namespace HumansVsAliens.Gameplay
{
    public class AbilityGood : IGood
    {
        private readonly IAbility _ability;

        public AbilityGood(IAbility ability)
        {
            _ability = ability ?? throw new ArgumentNullException(nameof(ability));
        }

        public void Buy()
        {
            if (_ability.IsActive)
                _ability.Deactivate();

            _ability.Activate();
        }
    }
}