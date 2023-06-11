using System;

namespace HumansVsAliens.View
{
    public sealed class HealthViewWithAnimations : IHealthView
    {
        private readonly IHealthView _view;
        private readonly IHealthAnimations _animations;

        private float _lastShowedHealth;

        public HealthViewWithAnimations(IHealthView view, IHealthAnimations animations)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _animations = animations ?? throw new ArgumentNullException(nameof(animations));
        }

        public HealthViewWithAnimations(IHealthAnimations healthAnimations) : this(new FakeHealthView(), healthAnimations)
        {
        }

        public void Visualize(int health)
        {
            _view.Visualize(health);

            if (_lastShowedHealth > health)
                _animations.PlayTakeDamage();
            
            _lastShowedHealth = health;
        }

        public void Die()
        {
            _view.Die();
            _animations.PlayDeath();
        }
    }
}