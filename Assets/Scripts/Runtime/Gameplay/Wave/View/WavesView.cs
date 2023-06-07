using System.Threading.Tasks;
using Photon.Pun;
using TMPro;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    [RequireComponent(typeof(PhotonView))]
    public class WavesView : MonoBehaviour, IWavesView
    {
        [SerializeField, Min(10)] private int _timeToStartWave = 30;
        [SerializeField] private TMP_Text _timer;

        private PhotonView _photonView;
        private Color _startTimerColor;

        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
            _startTimerColor = _timer.color;
        }

        public async Task StartWave()
        {
            float time = _timeToStartWave;

            while (time > 0)
            {
                time -= Time.deltaTime;
                _photonView.RPC(nameof(ShowTime), RpcTarget.All, time);
                await Task.Yield();
            }

            _photonView.RPC(nameof(Clear), RpcTarget.All);
        }

        [PunRPC]
        private void ShowTime(float time)
        {
            _timer.text = Mathf.RoundToInt(time).ToString();

            if (time <= _timeToStartWave / 2f && _timer.color != Color.red)
                _timer.color = Color.red;
        }

        [PunRPC]
        private void Clear()
        {
            _timer.color = _startTimerColor;
            _timer.text = string.Empty;
        }
    }
}