using HumansVsAliens.Model;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Factory
{
    public sealed class BladedWeaponFactory : MonoBehaviour, IBladedWeaponFactory
    {
        [SerializeField] private BladedWeaponView _prefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private CharacterAnimations _animations;
        [SerializeField] private int _damage = 10;

        public IBladedWeapon Create()
        {
            BladedWeaponView view = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity, _animations.transform);
            view.Init(_animations);
            view.Enable();
            return new BladedWeapon(view, _damage);
        }
    }
}