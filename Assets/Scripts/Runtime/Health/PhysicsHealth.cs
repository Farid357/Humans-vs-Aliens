using System;
using UnityEngine;

namespace HumansVsAliens.Model
{
    public sealed class PhysicsHealth : MonoBehaviour, IHealth
    {
        private IHealth _health;

        public void Init(IHealth health)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
        }
        
        public bool IsAlive => _health.IsAlive;

        public int Value => _health.Value;

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }
    }
}