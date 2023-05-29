using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class CharacterHealthFactory : MonoBehaviour
    {
        [SerializeField] private CharacterHealthView _healthView;

        public IHealth Create()
        {
            return new HealthWithHealClamp(new HealthWithView(new Health(100), _healthView));
        }
    }
}