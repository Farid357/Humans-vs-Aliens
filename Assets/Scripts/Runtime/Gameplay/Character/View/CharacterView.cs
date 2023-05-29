using UnityEngine;

namespace HumansVsAliens.View
{
    public sealed class CharacterView : MonoBehaviour, ICharacterView
    {
        [SerializeField] private CharacterAnimations _animations;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _changeWeaponSound;
        [SerializeField] private AudioClip _attackSound;
        
        public IHealthAnimations Animations => _animations;

        public void Attack()
        {
            _animations.PlayAttack();
            _audioSource.PlayOneShot(_attackSound);
        }

        public void SwitchWeapon()
        {
            _audioSource.PlayOneShot(_changeWeaponSound);
            _animations.SwitchWeapon();
        }
    }
}