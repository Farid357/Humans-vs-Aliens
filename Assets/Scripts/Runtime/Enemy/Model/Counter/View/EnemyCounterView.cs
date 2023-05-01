using DG.Tweening;
using TMPro;
using UnityEngine;

namespace HumansVsAliens.View
{
    public class EnemyCounterView : MonoBehaviour, IEnemyCounterView
    {
        [SerializeField] private TMP_Text _text;

        public int ShowingCount { get; private set; }

        public void Show(int enemiesCount)
        {
            if (ShowingCount > enemiesCount)
            {
                Color color = _text.color;
                _text.DOColor(Color.red, 0.4f).OnComplete(() => _text.color = color);
            }
            
            ShowingCount = enemiesCount;
            _text.text = enemiesCount.ToString();
        }
    }
}