using System;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public sealed class Weapon : IWeapon
    {
        private readonly IProjectileFactory _projectileFactory;
        private readonly IWeaponAim _aim;
        private readonly int _damage;

        public Weapon(IProjectileFactory projectileFactory, IWeaponAim aim, int damage)
        {
            _projectileFactory = projectileFactory ?? throw new ArgumentNullException(nameof(projectileFactory));
            _aim = aim ?? throw new ArgumentNullException(nameof(aim));
            _damage = damage.ThrowIfLessThanOrEqualsToZeroException();
        }

        public bool CanShoot => true;

        public void Shoot()
        {
            IProjectile projectile = _projectileFactory.Create(_damage);
            projectile.Throw(_aim.ShootDirection);
        }
    }
}