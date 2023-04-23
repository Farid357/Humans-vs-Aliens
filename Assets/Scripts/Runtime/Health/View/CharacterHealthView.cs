using System;
using UnityEngine;
using UnityEngine.UI;

namespace HumansVsAliens.View
{
    public sealed class CharacterHealthView : MonoBehaviour, IHealthView
    {
        [SerializeField] private Scrollbar _bar;
        [SerializeField] private Window _loseWindow;
        
        private IHealthAnimations _characterAnimations;

        public void Init(IHealthAnimations characterAnimations)
        {
            _characterAnimations = characterAnimations ?? throw new ArgumentNullException(nameof(characterAnimations));
        }
        
        public void Visualize(int health)
        {
            _bar.size = health / 100f;
            _characterAnimations.PlayGetHit();
        }

        public void Die()
        {
            _loseWindow.Open();
            _characterAnimations.PlayDeath();
        }
    }
}