using System;
using TMPro;
using UnityEngine;

namespace HumansVsAliens.View
{
    public sealed class CharacterHealthView : MonoBehaviour, IHealthView
    {
        [SerializeField] private HealthBar _bar;
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private Window _loseWindow;
        
        private IHealthAnimations _characterAnimations;

        public void Init(IHealthAnimations characterAnimations)
        {
            _characterAnimations = characterAnimations ?? throw new ArgumentNullException(nameof(characterAnimations));
        }
        
        public void Visualize(int health)
        {
            _healthText.text = $"{health}/100";
            _bar.Visualize(health, 100);
            _characterAnimations.PlayTakeDamage();
        }

        public void Die()
        {
            _loseWindow.Open();
            _characterAnimations.PlayDeath();
        }
    }
}