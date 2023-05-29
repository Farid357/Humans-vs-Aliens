using TMPro;
using UnityEngine;

namespace HumansVsAliens.View
{
    public sealed class CharacterHealthView : MonoBehaviour, IHealthView
    {
        [SerializeField] private HealthBar _bar;
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private Window _loseWindow;
        
        public void Visualize(int health)
        {
            _healthText.text = $"{health}/100";
            _bar.Visualize(health, 100);
        }

        public void Die()
        {
            _loseWindow.Open();
        }
    }
}