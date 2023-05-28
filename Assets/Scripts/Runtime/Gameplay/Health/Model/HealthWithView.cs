using System;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public sealed class HealthWithView : IHealth
    {
        private readonly IHealth _health;
        private readonly IHealthView _view;

        public HealthWithView(IHealth health, IHealthView view)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public bool IsAlive => _health.IsAlive;

        public int Value => _health.Value;

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
            _view.Visualize(Value);

            if (!IsAlive)
                _view.Die();
        }

        public void Heal(int heal)
        {
            _health.Heal(heal);
            _view.Visualize(Value);
        }
    }
}