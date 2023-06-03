using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace HumansVsAliens.View
{
    public class KillsStreakView : MonoBehaviour, IKillsStreakView
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField, Range(0.1f, 1f)] private float _changeTextSpeed = 0.35f;
        [SerializeField] private Animator _textAnimator;
        [SerializeField] private List<KillsStreakViewData> _data;

        private readonly int _shakeAnimationId = Animator.StringToHash("Shake");
        private KillsStreakViewData _currentData;

        private void Awake() => _currentData = _data[0];

        public void Visualize(int killStreak)
        {
            TrySwitchViewData(killStreak);
            _text.DOText(killStreak + "X", _changeTextSpeed, scrambleMode: ScrambleMode.Numerals);
            _text.color = _currentData.Color;
            _textAnimator.Play(_shakeAnimationId);
        }

        private void TrySwitchViewData(int killStreak)
        {
            if (_data.IndexOf(_currentData) == _data.Count) 
                return;
            
            KillsStreakViewData nextData = _data[_data.IndexOf(_currentData) + 1];
            if (_currentData.KillStreak < killStreak && killStreak == nextData.KillStreak)
            {
                _currentData = nextData;
            }
        }

        public void ResetFactor()
        {
            _text.text = string.Empty;
        }
    }
}