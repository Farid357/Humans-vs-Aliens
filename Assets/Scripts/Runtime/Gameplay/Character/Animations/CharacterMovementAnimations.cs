using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class CharacterMovementAnimations : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private const string Walk = "Walk";

        public void PlayMove(Vector3 direction)
        {
            if (direction == Vector3.zero)
            {
                PlayStay();
                return;
            }

            if (_animator.GetBool(Walk) == false)
                _animator.SetBool(Walk, true);
        }

        public void PlayStay()
        {
            _animator.SetBool(Walk, false);
        }

        public void PlayJump()
        {
            _animator.SetBool(Walk, false);
            _animator.Play("Jump");
        }
    }
}