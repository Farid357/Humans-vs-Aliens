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

        public BladedWeapon(IBladedWeaponView view, int damage, float maxHitDistance = 1.5f)
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

            Collider[] hits = Physics.OverlapSphere(View.Position, _maxHitDistance);
            foreach (Collider hit in hits)
            {
                if (hit != null && hit.TryGetComponent(out IEnemy enemy))
                {
                    enemy.Health.TakeDamage(_damage);
                }
            }
        }
    }
}