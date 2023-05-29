using System;

namespace HumansVsAliens.View
{
    public sealed class HealthViewWithAnimations : IHealthView
    {
        private readonly IHealthView _view;
        private readonly IHealthAnimations _healthAnimations;

        public HealthViewWithAnimations(IHealthView view, IHealthAnimations healthAnimations)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _healthAnimations = healthAnimations ?? throw new ArgumentNullException(nameof(healthAnimations));
        }

        public void Visualize(int health)
        {
            _view.Visualize(health);
            _healthAnimations.PlayTakeDamage();
        }

        public void Die()
        {
            _view.Die();
            _healthAnimations.PlayDeath();
        }
    }
}