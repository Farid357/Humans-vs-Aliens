using System;
using HumansVsAliens.Tools;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Model
{
    public sealed class BladedWeapon : IBladedWeapon
    {
        private readonly int _damage;
        private readonly float _maxHitDistance;
        private Collider[] _hits = new Collider[256];

        public BladedWeapon(IBladedWeaponView view, int damage, float maxHitDistance)
        {
            View = view ?? throw new ArgumentNullException(nameof(view));
            _damage = damage.ThrowIfLessThanOrEqualsToZeroException();
            _maxHitDistance = maxHitDistance.ThrowIfLessOrEqualsToZeroException();
        }

        public bool CanHit => View.IsActive;

        public IBladedWeaponView View { get; }

        public void Hit()
        {
            if (CanHit == false)
                throw new InvalidOperationException($"View is not active! You can't hit!");

            Physics.OverlapSphereNonAlloc(View.Position, _maxHitDistance, _hits);

            foreach (Collider hit in _hits)
            {
                if (hit != null && hit.TryGetComponent(out IEnemy enemy))
                {
                    enemy.Health.TakeDamage(_damage);
                }
            }
        }
    }
}