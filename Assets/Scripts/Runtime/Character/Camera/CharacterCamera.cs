using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Model
{
    [RequireComponent(typeof(Camera))]
    public class CharacterCamera : MonoBehaviour, ICharacterCamera
    {
        [SerializeField] private PhotonView _photonView;
        private Camera _camera;

        private void OnEnable()
        {
            _camera = GetComponent<Camera>();
            
            if(!_photonView.IsMine)
                Destroy(_camera.gameObject);
        }

        public void ZoomIn()
        {
            
        }

        public void ZoomOut()
        {
            
        }
    }
}