using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.View
{
    [RequireComponent(typeof(PhotonView))]
    public class VictoryView : MonoBehaviour, IVictoryView
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Window _victoryWindow;
        
        private PhotonView _photonView;

        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
        }

        public void ShowVictory()
        {
            _photonView.RPC(nameof(ShowVictoryRpc), RpcTarget.All);
        }
        
        [PunRPC]
        public void ShowVictoryRpc()
        {
            _victoryWindow.Open();
            _audioSource.Play();
        }
    }
}