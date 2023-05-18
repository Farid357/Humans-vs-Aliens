using DG.Tweening;
using TMPro;
using UnityEngine;

namespace HumansVsAliens.View
{
    public class EnemyCounterView : MonoBehaviour, IEnemyCounterView
    {
        [SerializeField] private TMP_Text _text;

        private int _showingCount;

        public void Show(int enemiesCount)
        {
            if (_showingCount > enemiesCount)
            {
                Color color = _text.color;
                _text.DOColor(Color.red, 0.4f).OnComplete(() => _text.color = color);
            }

            _showingCount = enemiesCount;
            _text.text = enemiesCount.ToString();
        }
    }
}