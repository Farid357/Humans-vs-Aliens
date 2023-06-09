using System;
using Sirenix.Utilities.Editor;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class CharacterControllerMovement : MonoBehaviour, ICharacterMovement
    {
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private float _speed = 1.5f;
        [SerializeField] private CharacterMovementAnimations _animations;
        [SerializeField] private Transform _camera;

        private CharacterController _controller;
        private float _velocity;

        public Vector3 Position => transform.position;

        public bool OnGround => Physics.Raycast(transform.position, Vector3.down, 0.9f);

        private void OnEnable() => _controller = GetComponent<CharacterController>();

        public void Move(Vector3 direction)
        {
            direction = _camera.TransformDirection(direction);
            _controller.Move(direction * _speed);
            _animations.PlayMove(direction);
        }

        public void Jump()
        {
            if (OnGround == false)
                throw new InvalidOperationException($"Can't jump! Character is not on ground!");

            _velocity = _jumpForce;
            _animations.PlayJump();
        }

        private void Update()
        {
            if (OnGround && _velocity < 0)
                _velocity = 0;

            _velocity += Physics.gravity.y * Time.deltaTime;
            _controller.Move(transform.up * _velocity * Time.deltaTime);
        }
    }
}