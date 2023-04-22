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
        
        public ICharacter Create()
        {
            Character character = Instantiate(_prefab, Vector3.zero, Quaternion.identity);
            IHealth health = new Health(_healthView, 100);
            IBladedWeapon weapon = _weaponFactory.Create(character.transform);
            character.Init(health, weapon);
            _healthView.Init(character.Animations);
            return character;
        }
    }
}