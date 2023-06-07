using Photon.Pun;
using TMPro;
using UnityEngine;

namespace HumansVsAliens.View
{
    [RequireComponent(typeof(PhotonView))]
    public class WavesCounterView : MonoBehaviour, IWavesCounterView
    {
        [SerializeField] private TMP_Text _text;

        private PhotonView _photonView;

        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
        }

        public void Visualize(int pastWaves)
        {
            _photonView.RPC(nameof(VisualizeRpc), RpcTarget.All, pastWaves);
        }
        
        [PunRPC]
        private void VisualizeRpc(int pastWaves)
        {
            _text.text = pastWaves.ToString();
        }
    }
}