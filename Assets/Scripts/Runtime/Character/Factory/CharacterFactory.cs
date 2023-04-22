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
        [SerializeField] private BladedWeaponsCollectionView _bladedWeaponsCollectionView;

        public ICharacter Create()
        {
            Character character = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
            IHealth health = new Health(_healthView, 100);
            IBladedWeapon weapon = _weaponFactory.Create(character.transform);
            IBladedWeaponsCollection weaponsCollection = new BladedWeaponsCollection(weapon, _bladedWeaponsCollectionView);
            _bladedWeaponsCollectionView.SwitchWeapon(weapon);
            character.Init(health, weaponsCollection);
            _healthView.Init(character.Animations);
            _camera.transform.SetParent(character.transform);
            return character;
        }
    }
}