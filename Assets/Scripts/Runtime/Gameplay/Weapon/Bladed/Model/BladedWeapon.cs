using System;
using HumansVsAliens.Tools;
using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class BladedWeapon : IBladedWeapon
    {
        private readonly Collider[] _hits = new Collider[40];
        private readonly LayerMask _layerMask;
       
        private readonly int _damage;
        private readonly float _hitRadius;

        public BladedWeapon(IBladedWeaponView view, int damage, float hitRadius, LayerMask layerMask)
        {
            View = view ?? throw new ArgumentNullException(nameof(view));
            _damage = damage.ThrowIfLessThanOrEqualsToZeroException();
            _hitRadius = hitRadius.ThrowIfLessOrEqualsToZeroException();
            _layerMask = layerMask;
        }

        public bool CanHit => View.IsActive;

        public IBladedWeaponView View { get; }

        public void Hit()
        {
            if (CanHit == false)
                throw new InvalidOperationException($"View is not active! You can't hit!");

            int overlaps = Physics.OverlapSphereNonAlloc(View.Position, _hitRadius, _hits, _layerMask);

            for (int i = 0; i < overlaps; i++)
            {
                if (_hits[i].TryGetComponent(out IEnemy enemy) && enemy.Health.IsAlive)
                {
                    enemy.Health.TakeDamage(_damage);
                }
            }
        }
    }
}