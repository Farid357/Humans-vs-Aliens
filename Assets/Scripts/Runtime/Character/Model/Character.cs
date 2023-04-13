using System;
using UnityEngine;

namespace HumansVsAliens.Model
{
    public sealed class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] private PhysicsHealth _physicsHealth;
        private IBladedWeapon _weapon;

        public void Init(IHealth health, IBladedWeapon weapon)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _physicsHealth.Init(health);
        }

        public bool IsAlive => _physicsHealth.IsAlive;

        public bool CanAttack => _weapon.CanHit;
        
        public ICharacterMovement Movement { get; }
        
        public void Attack()
        {
            if (!IsAlive)
                throw new InvalidOperationException($"Character is not alive!");
            
            if(!CanAttack)
                throw new InvalidOperationException($"Character can't attack!");
        }

        public void SwitchWeapon(IBladedWeapon weapon)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }
    }
}