using Photon.Pun;
using TMPro;
using UnityEngine;

namespace HumansVsAliens.View
{
    [RequireComponent(typeof(PhotonView))]
    public class TimerBetweenWavesView : MonoBehaviour, ITimerBetweenWavesView
    {
        [SerializeField] private TMP_Text _text;
        
        private PhotonView _photonView;

        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
        }

        public void Clear()
        {
            _photonView.RPC(nameof(ClearRpc), RpcTarget.All);
        }

        public void Visualize(int time)
        {
            _photonView.RPC(nameof(VisualizeRpc), RpcTarget.All, time);
        }

        [PunRPC]
        private void VisualizeRpc(int time)
        {
            _text.color = time <= 10 ? Color.red : Color.white;
            _text.text = time.ToString();
        }
        
        [PunRPC]
        private void ClearRpc()
        {
            _text.text = string.Empty;
        }
    }
}