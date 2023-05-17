using UnityEngine;

namespace HumansVsAliens.Model
{
    public sealed class CharacterMovementAnimations : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private const string Walk = "Walk";

        public void PlayMove(Vector3 direction)
        {
            if (direction == Vector3.zero)
            {
                _animator.SetBool(Walk, false);
                return;
            }

            if (_animator.GetBool(Walk) == false)
                _animator.SetBool(Walk, true);
        }

        public void PlayJump()
        {
            _animator.SetBool(Walk, false);
            _animator.Play("Jump");
        }
    }
}