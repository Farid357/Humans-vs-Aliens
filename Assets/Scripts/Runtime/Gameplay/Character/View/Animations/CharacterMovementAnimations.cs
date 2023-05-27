using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class CharacterMovementAnimations : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
       
        private static readonly int _walk = Animator.StringToHash("Walk");

        public void PlayMove(Vector3 direction)
        {
            if (direction == Vector3.zero)
            {
                PlayStay();
                return;
            }

            if (_animator.GetBool(_walk) == false)
                _animator.SetBool(_walk, true);
        }

        public void PlayJump()
        {
            _animator.SetBool(_walk, false);
            _animator.Play("Jump");
        }

        private void PlayStay()
        {
            _animator.SetBool(_walk, false);
        }
    }
}