using Photon.Pun;
using System;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    [RequireComponent(typeof(Camera), typeof(PhotonView))]
    public class CharacterCamera : MonoBehaviour, ICharacterCamera
    {
        [SerializeField, Min(10)] private float _maxZoomIn = 45;
        
        private Camera _camera;
        private float _maxZoomOut;
        
        public bool IsInFullZoomIn => _camera.fieldOfView <= _maxZoomIn;

        public bool IsInFullZoomOut => _camera.fieldOfView >= _maxZoomOut;

        private void OnEnable()
        {
            _camera = GetComponent<Camera>();
            PhotonView photonView = GetComponent<PhotonView>();
            _maxZoomOut = _camera.fieldOfView;

            if (!photonView.IsMine)
                Destroy(_camera.gameObject);
        }

        public void ZoomIn()
        {
            if (IsInFullZoomIn)
                throw new InvalidOperationException(nameof(ZoomIn));

            _camera.fieldOfView -= 1f;
        }

        public void ZoomOut()
        {
            if (IsInFullZoomOut)
                throw new InvalidOperationException(nameof(ZoomOut));

            _camera.fieldOfView += 1f;
        }
    }
}