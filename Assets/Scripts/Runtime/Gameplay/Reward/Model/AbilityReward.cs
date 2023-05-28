using System;

namespace HumansVsAliens.Gameplay
{
    public class AbilityReward : IReward
    {
        private readonly IAbility _ability;

        public AbilityReward(IAbility ability)
        {
            _ability = ability ?? throw new ArgumentNullException(nameof(ability));
        }

        public void Receive()
        {
            if(_ability.IsActive)
                _ability.Deactivate();
            
            _ability.Activate();
        }
    }
}