using DG.Tweening;
using TMPro;
using UnityEngine;

namespace HumansVsAliens.View
{
    public class ScoreView : MonoBehaviour, IScoreView
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Color _colorWhenReceivedScore = Color.yellow;
        [SerializeField] private float _colorChangeDuration = 1.5f;
    
        private Color _startColor;

        private void Start()
        {
            _startColor = _text.color;
        }

        public void Visualize(int score)
        {
            _text.text = score.ToString();
            _text.DOColor(_colorWhenReceivedScore, _colorChangeDuration).OnComplete(() =>  ReturnToStart());
        }

        private void ReturnToStart()
        {
            _text.DOColor(_startColor, _colorChangeDuration / 3f);
        }
    }
}