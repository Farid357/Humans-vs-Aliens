using HumansVsAliens.View;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class CharacterFactory : MonoBehaviour, ICharacterFactory
    {
        [SerializeField] private Character _prefab;
        [SerializeField] private BladedWeaponFactory _weaponFactory;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private BladedWeaponsCollectionView _bladedWeaponsCollectionView;
        [SerializeField] private InvulnerabilityFactory _invulnerabilityFactory;
        [SerializeField] private CharacterHealthView _healthView;
        
        public ICharacter Create(out IInvulnerability invulnerability)
        {
            Character character = PhotonNetwork.Instantiate(_prefab.name, _spawnPoint.position, Quaternion.identity).GetComponent<Character>();
            IBladedWeapon weapon = _weaponFactory.Create(character.WeaponPositionTransform);
            IBladedWeaponsCollection weaponsCollection = new BladedWeaponsCollection(weapon, _bladedWeaponsCollectionView);
            _bladedWeaponsCollectionView.SwitchWeapon(weapon);
            invulnerability = null;
            character.Init(weaponsCollection, 100, _healthView);
            return character;
        }
    }
}