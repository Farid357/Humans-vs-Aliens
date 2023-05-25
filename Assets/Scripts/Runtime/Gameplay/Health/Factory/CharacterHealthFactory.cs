using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class CharacterHealthFactory : MonoBehaviour, ICharacterHealthFactory
    {
        [SerializeField] private CharacterHealthView _healthView;

        public IHealth Create(IHealthAnimations animations)
        {
            _healthView.Init(animations);
            return new HealthWithHealClamp(new Health(_healthView, 100));
        }
    }
}