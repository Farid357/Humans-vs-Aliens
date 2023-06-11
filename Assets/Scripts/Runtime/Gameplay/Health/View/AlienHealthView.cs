using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.View
{
    [RequireComponent(typeof(PhotonView))]
    public class AlienHealthView : MonoBehaviour, IHealthView
    {
        [SerializeField] private HealthAnimations _animations;

        private IHealthView _healthView;
        private PhotonView _photonView;
        
        private void OnEnable()
        {
            _photonView ??= GetComponent<PhotonView>();
            _healthView ??= new HealthViewWithAnimations(_animations);
        }

        public void Visualize(int health)
        {
            _healthView.Visualize(health);
        }

        public void Die()
        {
            _photonView.RPC(nameof(DisableSelf), RpcTarget.All);
        }

        [PunRPC]
        private void DisableSelf()
        {
            gameObject.SetActive(false);
        }
    }
}