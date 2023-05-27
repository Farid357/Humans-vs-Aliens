using System;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] private CharacterControllerMovement _movement;
        [SerializeField] private CharacterAnimations _animations;
        [SerializeField] private CharacterCamera _camera;

        private IBladedWeaponsCollection _weaponsCollection;

        public void Init(IHealth health, IBladedWeaponsCollection weaponsCollection)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
            _weaponsCollection = weaponsCollection ?? throw new ArgumentNullException(nameof(weaponsCollection));
        }

        public IHealth Health { get; private set; }

        public bool IsAlive => Health.IsAlive;

        public bool CanAttack => _weaponsCollection.Weapon.CanHit;

        public IMovementWithJump Movement => _movement;

        public ICharacterCamera Camera => _camera;

        public IHealthAnimations Animations => _animations;

        public void Attack()
        {
            if (!IsAlive)
                throw new InvalidOperationException($"Character is not alive!");

            if (!CanAttack)
                throw new InvalidOperationException($"Character can't attack!");

            _weaponsCollection.Weapon.Hit();
            _animations.PlayAttack();
        }

        public void SwitchWeapon(IBladedWeapon weapon)
        {
            if (!IsAlive)
                throw new InvalidOperationException($"Character is not alive!");

            _weaponsCollection.Weapon.View.Disable();
            weapon.View.Enable();
            _weaponsCollection.SwitchWeapon(weapon);
        }
    }
}