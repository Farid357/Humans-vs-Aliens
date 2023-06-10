using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class WeaponFactory : MonoBehaviour
    {
        [SerializeField] private ProjectileFactory _projectileFactory;
        [SerializeField] private WeaponView _prefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField, Range(1, 1000)] private int _damage = 10;

        public IWeapon Create(IWeaponAim aim)
        {
            Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
            return new Weapon(_projectileFactory, aim, _damage);
        }
    }
}