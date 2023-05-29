using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.View
{
    [RequireComponent(typeof(Animator))]
    public sealed class CharacterAnimations : MonoBehaviour, ICharacterAnimations
    {
        [SerializeField] private string[] _attacks;

        private Animator _animator;

        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayDeath()
        {
            _animator.Play("Death");
        }

        public void PlayTakeDamage()
        {
            _animator.Play("Get Hit");
        }

        public void PlayAttack()
        {
            string randomAttack = _attacks.GetRandom();
            _animator.Play(randomAttack);
        }

        public void SwitchWeapon()
        {
            //TODO Animation
        }
    }
}