using TMPro;
using UnityEngine;

namespace HumansVsAliens.Model
{
    public class TimerBetweenWavesView : MonoBehaviour, ITimerBetweenWavesView
    {
        [SerializeField] private TMP_Text _text;

        public void Clear()
        {
            _text.text = string.Empty;
        }

        public void Visualize(float time)
        {
            _text.text = Mathf.RoundToInt(time).ToString();
        }
    }
}