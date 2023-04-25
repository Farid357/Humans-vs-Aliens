using UnityEngine;

namespace HumansVsAliens.Model
{
    public sealed class CharacterMovementAnimations : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        public void PlayMove(Vector3 direction)
        {
            if (direction == Vector3.zero)
            {
                _animator.Play("Idle");
                return;
            }
            
            _animator.Play("Walk");
        }

        public void PlayJump()
        {
            _animator.Play("Jump");
        }
    }
}