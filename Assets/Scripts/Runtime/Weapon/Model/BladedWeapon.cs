using System;
using HumansVsAliens.Tools;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Model
{
    public sealed class BladedWeapon : IBladedWeapon
    {
        private readonly int _damage;
        private readonly float _hitRadius;
        private readonly LayerMask _layerMask;
        private Collider[] _hits = new Collider[40];

        public BladedWeapon(IBladedWeaponView view, int damage, float hitRadius, LayerMask layerMask)
        {
            View = view ?? throw new ArgumentNullException(nameof(view));
            _layerMask = layerMask;
            _damage = damage.ThrowIfLessThanOrEqualsToZeroException();
            _hitRadius = hitRadius.ThrowIfLessOrEqualsToZeroException();
        }

        public bool CanHit => View.IsActive;

        public IBladedWeaponView View { get; }

        public void Hit()
        {
            if (CanHit == false)
                throw new InvalidOperationException($"View is not active! You can't hit!");

            Physics.OverlapSphereNonAlloc(View.Position, _hitRadius, _hits, _layerMask);

            foreach (Collider hit in _hits)
            {
                if (hit != null && hit.TryGetComponent(out IEnemy enemy))
                {
                    enemy.Health.TakeDamage(_damage);
                }
            }

            _hits = new Collider[40];
        }
    }
}