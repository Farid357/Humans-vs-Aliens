using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace HumansVsAliens.View
{
    public sealed class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _bar;
        [SerializeField] private float _changeHealthDuration = 1.5f;

        public void Visualize(int health, int maxHealth)
        {
            _bar.DOFillAmount((float)health / maxHealth, _changeHealthDuration);
        }
    }
}