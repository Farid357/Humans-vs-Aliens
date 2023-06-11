using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.View
{
    [RequireComponent(typeof(Animator))]
    public sealed class CharacterAnimations : MonoBehaviour, ICharacterAnimations
    {
        [SerializeField] private HealthAnimations _healthAnimations;
        [SerializeField] private string[] _attacks;

        private Animator _animator;

        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayDeath()
        {
            _healthAnimations.PlayDeath();
        }

        public void PlayTakeDamage()
        {
            _healthAnimations.PlayTakeDamage();
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