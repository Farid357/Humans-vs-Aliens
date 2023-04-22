using System;
using HumansVsAliens.Model;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Factory
{
    public sealed class CharacterFactory : MonoBehaviour, ICharacterFactory
    {
        [SerializeField] private CharacterHealthView _healthView;
        [SerializeField] private Character _prefab;
        [SerializeField] private BladedWeaponFactory _weaponFactory;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Camera _camera;

        public ICharacter Create()
        {
            Character character = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
            IHealth health = new Health(_healthView, 100);
            IBladedWeapon weapon = _weaponFactory.Create(character.transform);
            character.Init(health, weapon);
            _healthView.Init(character.Animations);
            _camera.transform.SetParent(character.transform);
            return character;
        }
    }
}