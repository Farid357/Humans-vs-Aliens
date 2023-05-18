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
        //private Vector3 _rotation = new();
        //private readonly float _sensitivity = 1.5f;

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

        //private void Update()
        //{
        //    _rotation.x += Mouse.current.delta.x.ReadValue() * _sensitivity;
        //    _rotation.y += Mouse.current.delta.y.ReadValue() * _sensitivity;
        //    _rotation.y = Mathf.Clamp(_rotation.y, -90, 90);
        //    _camera.transform.rotation = Quaternion.Euler(-_rotation.y, _rotation.x, 0);
        //}
    }
}