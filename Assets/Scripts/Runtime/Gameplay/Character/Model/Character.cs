using System;
using HumansVsAliens.View;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    [RequireComponent(typeof(PhotonView))]
    public sealed class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] private CharacterView _view;
        [SerializeField] private CharacterControllerMovement _movement;
        [SerializeField] private CharacterCamera _camera;

        private IBladedWeaponsCollection _weaponsCollection;
        
        [PunRPC]
        public void Init(int health)
        {
            Health = new Health(health);
        }

        public void InitLocal(IBladedWeaponsCollection weaponsCollection, IHealthView healthView)
        {
            Health = new HealthWithView(Health, healthView);
            _weaponsCollection = weaponsCollection ?? throw new ArgumentNullException(nameof(weaponsCollection));
        }

        public IHealth Health { get; private set; }
        
        public bool IsAlive => Health.IsAlive;

        public bool CanAttack => _weaponsCollection.Weapon.CanHit;

        public IMovementWithJump Movement => _movement;

        public ICharacterCamera Camera => _camera;
        
        public IHealthAnimations Animations => _view.Animations;

        public void Attack()
        {
            if (!IsAlive)
                throw new InvalidOperationException($"Character is not alive!");

            if (!CanAttack)
                throw new InvalidOperationException($"Character can't attack!");

            _weaponsCollection.Weapon.Hit();
            _view.Attack();
        }

        public void SwitchWeapon(IBladedWeapon weapon)
        {
            if (!IsAlive)
                throw new InvalidOperationException($"Character is not alive!");

            _weaponsCollection.Weapon.View.Disable();
            weapon.View.Enable();
            _weaponsCollection.SwitchWeapon(weapon);
            _view.SwitchWeapon();
        }
    }
}