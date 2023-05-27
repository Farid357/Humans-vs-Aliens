using System;

namespace HumansVsAliens.Gameplay
{
    public class AbilityBonus : IBonus
    {
        private readonly IBonus _bonus;
        private readonly IAbility _ability;

        public AbilityBonus(IBonus bonus, IAbility ability)
        {
            _bonus = bonus ?? throw new ArgumentNullException(nameof(bonus));
            _ability = ability ?? throw new ArgumentNullException(nameof(ability));
        }

        public void PickUp()
        {
            _bonus.PickUp();

            if (_ability.IsActive)
                _ability.Deactivate();

            _ability.Activate();
        }
    }
}