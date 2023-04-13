using TMPro;
using UnityEngine;

namespace HumansVsAliens.View
{
    public sealed class CharacterHealthView : MonoBehaviour, IHealthView
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Window _loseWindow;
        
        public void Visualize(int health)
        {
            _text.text = $"{health}/100";
        }

        public void Die()
        {
            _loseWindow.Open();
        }
    }
}