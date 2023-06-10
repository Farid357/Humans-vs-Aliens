using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour, IProjectile
    {
        [SerializeField, Range(1, 1000)] private float _throwForce = 10f;

        private Rigidbody _rigidbody;
        private int _damage;

        public void Init(int damage)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _damage = damage.ThrowIfLessThanOrEqualsToZeroException();
        }

        public void Throw(Vector3 direction)
        {
            _rigidbody.AddForce(direction * _throwForce, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out IReadOnlyCharacter character))
            {
                if (character.IsAlive)
                    character.Health.TakeDamage(_damage);
            }
        }
    }
}