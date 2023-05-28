using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class ChestRewardFactory : MonoBehaviour, IRewardFactory
    {
        private IAbility[] _abilities;

        public void Init(IInvulnerability invulnerability)
        {
            _abilities = new IAbility[]
            {
                invulnerability,
            };
        }

        public IReward Create()
        {
            IAbility ability = _abilities.GetRandom();
            return new AbilityReward(ability);
        }
    }
}