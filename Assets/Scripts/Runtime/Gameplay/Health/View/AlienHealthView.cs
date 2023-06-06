using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.View
{
    [RequireComponent(typeof(PhotonView))]
    public class AlienHealthView : MonoBehaviour, IHealthView
    {
        private PhotonView _photonView;

        private void OnEnable()
        {
            _photonView ??= GetComponent<PhotonView>();
        }

        public void Visualize(int health)
        {
        }

        public void Die()
        {
            _photonView.RPC(nameof(DestroySelf), RpcTarget.All);
        }

        [PunRPC]
        private void DestroySelf()
        {
           gameObject.SetActive(false);
        }
    }
}