using System;
using HumansVsAliens.Model;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Factory
{
    public sealed class BladedWeaponFactory : MonoBehaviour, IBladedWeaponFactory
    {
        [SerializeField] private BladedWeaponView _prefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private int _damage = 10;
        [SerializeField] private float _hitDistance = 10f;

        public IBladedWeapon Create(Transform parent)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            
            BladedWeaponView view = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity, parent);
            view.Enable();
            return new BladedWeapon(view, _damage, _hitDistance);
        }
    }
}