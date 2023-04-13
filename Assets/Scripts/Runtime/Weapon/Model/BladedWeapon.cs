using System;
using HumansVsAliens.Tools;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Model
{
    public sealed class BladedWeapon : IBladedWeapon
    {
        private readonly IBladedWeaponView _view;
        private readonly int _damage;
        private readonly float _maxHitDistance;

        public BladedWeapon(IBladedWeaponView view, int damage, float maxHitDistance = 1.5f)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _damage = damage.ThrowIfLessThanOrEqualsToZeroException();
            _maxHitDistance = maxHitDistance.ThrowIfLessOrEqualsToZeroException();
        }

        public bool CanHit => _view.IsActive;
        
        public IBladedWeaponActivityView View => _view;

        public async void Hit()
        {
            if (CanHit == false)
                throw new InvalidOperationException($"View is not active! You can't hit!");
            
            await _view.Hit();

            if (Physics.Raycast(_view.Position, Vector3.forward, out RaycastHit hitInfo, _maxHitDistance))
            {
                if (hitInfo.collider != null && hitInfo.collider.TryGetComponent(out IHealth health))
                {
                    health.TakeDamage(_damage);
                }
            }
        }
    }
}