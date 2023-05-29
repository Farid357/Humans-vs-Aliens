using Photon.Pun;
using System;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    [RequireComponent(typeof(Camera))]
    public class CharacterCamera : MonoBehaviour, ICharacterCamera
    {
        [SerializeField] private PhotonView _photonView;
        [SerializeField, Min(10)] private float _maxZoomIn = 45;

        private float _maxZoomOut;
        private Camera _camera;

        public bool IsInFullZoomIn => _camera.fieldOfView <= _maxZoomIn;

        public bool IsInFullZoomOut => _camera.fieldOfView >= _maxZoomOut;

        private void OnEnable()
        {
            _camera = GetComponent<Camera>();
            _maxZoomOut = _camera.fieldOfView;

            if(!_photonView.IsMine)
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