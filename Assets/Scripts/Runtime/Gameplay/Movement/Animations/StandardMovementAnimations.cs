using UnityEngine;

namespace HumansVsAliens.Model
{
    [RequireComponent(typeof(Animator))]
    public sealed class StandardMovementAnimations : MovementAnimations
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public override void PlayMove(Vector3 direction)
        {
            if (direction == Vector3.zero)
                _animator.Play("Idle");

            _animator.Play("Walk");
        }
    }
}