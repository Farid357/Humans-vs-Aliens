using System;
using TMPro;
using UnityEngine;

namespace HumansVsAliens.View
{
    public sealed class CharacterHealthView : MonoBehaviour, IHealthView
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Window _loseWindow;
        
        private ICharacterAnimations _characterAnimations;

        public void Init(ICharacterAnimations characterAnimations)
        {
            _characterAnimations = characterAnimations ?? throw new ArgumentNullException(nameof(characterAnimations));
        }
        
        public void Visualize(int health)
        {
            _text.text = $"{health}/100";
            _characterAnimations.PlayGetHit();
        }

        public void Die()
        {
            _loseWindow.Open();
            _characterAnimations.PlayDeath();
        }
    }
}