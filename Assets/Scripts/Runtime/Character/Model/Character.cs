using System;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Model
{
    public sealed class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] private CharacterMovement _movement;
        [SerializeField] private CharacterAnimations _animations;
        
        private IBladedWeapon _weapon;

        public void Init(IHealth health, IBladedWeapon weapon)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public IHealth Health { get; private set; }
       
        public bool IsAlive => Health.IsAlive;

        public bool CanAttack => _weapon.CanHit;

        public ICharacterMovement Movement => _movement;

        public ICharacterAnimations Animations => _animations;
        
        public void Attack()
        {
            if (!IsAlive)
                throw new InvalidOperationException($"Character is not alive!");
            
            if(!CanAttack)
                throw new InvalidOperationException($"Character can't attack!");
            
            _weapon.Hit();
            _animations.PlayAttack();
        }

        public void SwitchWeapon(IBladedWeapon weapon)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }
    }
}