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
        [SerializeField] private BladedWeaponFactory _weaponFactory;

        private IBladedWeaponsCollection _weaponsCollection;
        
        public void Init(IBladedWeaponsCollectionView weaponsCollectionView, int health, IHealthView healthView)
        {
            GetComponent<PhotonView>().RPC(nameof(InitRpc), RpcTarget.AllBuffered, health);
            Health = new HealthWithView(Health, new HealthViewWithAnimations(healthView, _view.Animations));
            _weaponsCollection = new BladedWeaponsCollection(_weaponFactory.Create(), weaponsCollectionView);
        }

        [PunRPC]
        private void InitRpc(int health) => Health = new HealthWithHealClamp(new Health(health));

        public bool IsAlive => Health.IsAlive;

        public bool CanAttack => _weaponsCollection.Weapon.CanHit;
        
        public IHealth Health { get; private set; }

        public ICharacterMovement Movement => _movement;

        public ICharacterCamera Camera => _camera;
        
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
            
            _weaponsCollection.SwitchWeapon(weapon);
            _view.SwitchWeapon();
        }
    }
}