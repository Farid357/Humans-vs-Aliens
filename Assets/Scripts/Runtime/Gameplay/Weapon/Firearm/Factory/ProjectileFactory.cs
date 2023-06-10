using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class ProjectileFactory : MonoBehaviour, IProjectileFactory
    {
        [SerializeField] private Projectile _projectilePrefab;

        public IProjectile Create(int damage)
        {
            Projectile projectile = Instantiate(_projectilePrefab, Vector3.right, Quaternion.identity);
            projectile.Init(damage);
            return projectile;
        }
    }
}