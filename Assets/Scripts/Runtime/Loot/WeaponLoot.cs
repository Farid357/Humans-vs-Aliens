using System;
using HumansVsAliens.Factory;
using UnityEngine;

namespace HumansVsAliens.Model
{
    public sealed class WeaponLoot : Loot
    {
        [SerializeField] private BladedWeaponFactory _weaponFactory;
        
        private ICharacter _character;

        public void Init(ICharacter character)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character));
        }
        
        protected override void Pick()
        {
            Transform parent = _character.Movement.Transform;
            IBladedWeapon weapon = _weaponFactory.Create(parent);
            _character.SwitchWeapon(weapon);
        }
    }
}