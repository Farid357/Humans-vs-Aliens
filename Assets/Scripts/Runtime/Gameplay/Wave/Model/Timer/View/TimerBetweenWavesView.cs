using TMPro;
using UnityEngine;

namespace HumansVsAliens.View
{
    public class TimerBetweenWavesView : MonoBehaviour, ITimerBetweenWavesView
    {
        [SerializeField] private TMP_Text _text;

        public void Clear()
        {
            _text.text = string.Empty;
        }

        public void Visualize(int time)
        {
            _text.text = time.ToString();
        }
    }
}