using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class EnemyWavesView : MonoBehaviour, IEnemyWavesView
    {
        [SerializeField, Min(10)] private int _timeToStartWave = 30;
        [SerializeField] private TMP_Text _timer;

        public async Task StartWave()
        {
            float time = _timeToStartWave;
            Color startTimerColor = _timer.color;
            _timer.color = Color.white;

            while(time > 0)
            {
                time -= Time.deltaTime;
                _timer.text = Mathf.RoundToInt(time).ToString();

                if (time <= _timeToStartWave / 2f && _timer.color != Color.red)
                    _timer.color = Color.red;

                await Task.Yield();
            }

            _timer.color = startTimerColor;
            _timer.text = string.Empty;
        }
    }
}