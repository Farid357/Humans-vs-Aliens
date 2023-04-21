using System;
using UnityEngine;

namespace HumansVsAliens.Model
{
    public sealed class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] private CharacterMovement _movement;
        
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
        
        public void Attack()
        {
            if (!IsAlive)
                throw new InvalidOperationException($"Character is not alive!");
            
            if(!CanAttack)
                throw new InvalidOperationException($"Character can't attack!");
            
            _weapon.Hit();
        }

        public void SwitchWeapon(IBladedWeapon weapon)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }
    }
}