using UnityEngine;

namespace HumansVsAliens.View
{
    [RequireComponent(typeof(Animator))]
    public sealed class CharacterAnimations : MonoBehaviour
    {
        private Animator _animator;

        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayDeath()
        {
            _animator.Play("Death");
        }
    }
}