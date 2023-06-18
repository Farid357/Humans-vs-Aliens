using Cysharp.Threading.Tasks;
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

        private void Awake() => _photonView = GetComponent<PhotonView>();

        public async UniTask StartFirstWave()
        {
            float time = _timeToStartWave;

            while (time > 0)
            {
                time -= Time.deltaTime;
                _photonView.RPC(nameof(ShowTime), RpcTarget.All, time);
                await UniTask.Yield();
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
            _timer.color = Color.white;
            _timer.text = string.Empty;
        }
    }
}