using HumansVsAliens.View;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class CharacterFactory : MonoBehaviour, ICharacterFactory
    {
        [SerializeField] private Character _prefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private BladedWeaponsCollectionView _bladedWeaponsCollectionView;
        [SerializeField] private InvulnerabilityFactory _invulnerabilityFactory;
        [SerializeField] private CharacterHealthView _healthView;
        
        public ICharacter Create()
        {
            Character character = PhotonNetwork.Instantiate(_prefab.name, _spawnPoint.position, Quaternion.identity).GetComponent<Character>();
            character.Init(_bladedWeaponsCollectionView, 100, _healthView);
            return character;
        }
    }
}