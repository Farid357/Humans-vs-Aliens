using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class CharacterFactory : MonoBehaviour, ICharacterFactory
    {
        [SerializeField] private Character _prefab;
        [SerializeField] private CharacterHealthFactory _healthFactory;
        [SerializeField] private BladedWeaponFactory _weaponFactory;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private BladedWeaponsCollectionView _bladedWeaponsCollectionView;
        [SerializeField] private InvulnerabilityFactory _invulnerabilityFactory;
        
        public ICharacter Create(out IInvulnerability invulnerability)
        {
            Character character = PhotonNetwork.Instantiate(_prefab.name, _spawnPoint.position, Quaternion.identity).GetComponent<Character>();
            IBladedWeapon weapon = _weaponFactory.Create(character.transform);
            IBladedWeaponsCollection weaponsCollection = new BladedWeaponsCollection(weapon, _bladedWeaponsCollectionView);
            _bladedWeaponsCollectionView.SwitchWeapon(weapon);
            IHealth health = _healthFactory.Create(character.Animations);
            invulnerability = _invulnerabilityFactory.Create(health);
            character.Init(invulnerability, weaponsCollection);
            return character;
        }
    }
}