using Photon.Pun;
using System;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    [RequireComponent(typeof(Camera), typeof(PhotonView))]
    public class CharacterCamera : MonoBehaviour, ICharacterCamera
    {
        [SerializeField, Min(10)] private float _maxZoomIn = 45;
        [SerializeField] private Transform _target;
        [SerializeField] private int _minPitch = -30;
        [SerializeField] private int _maxPitch = 70;
        
        private Camera _camera;
        private float _maxZoomOut;
        private float _targetYaw;
        private float _targetPitch;

        public bool IsInFullZoomIn => _camera.fieldOfView <= _maxZoomIn;

        public bool IsInFullZoomOut => _camera.fieldOfView >= _maxZoomOut;

        private void OnEnable()
        {
            _camera = GetComponent<Camera>();
            PhotonView photonView = GetComponent<PhotonView>();
            _maxZoomOut = _camera.fieldOfView;
            transform.SetParent(null);

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

        public void Rotate(Vector2 delta)
        {
            _targetYaw += delta.x * Time.deltaTime;
            _targetPitch += delta.y * Time.deltaTime;
            _targetYaw = Mathf.Clamp(_targetYaw, -360, 360);
            _targetPitch = Mathf.Clamp(_targetPitch, _minPitch, _maxPitch);
            _target.rotation = Quaternion.Euler(_targetPitch, _targetYaw, 0f);
        }
    }
}