using UnityEngine;

namespace HumansVsAliens.View
{
    [RequireComponent(typeof(Animator))]
    public sealed class HealthAnimations : MonoBehaviour, IHealthAnimations
    {
        private Animator _animator;

        private void OnEnable()
        {
            _animator ??= GetComponent<Animator>();
        }

        public void PlayDeath()
        {
            _animator.Play("Death");
        }

        public void PlayTakeDamage()
        {
            _animator.Play("Get Hit");
        }
    }
}