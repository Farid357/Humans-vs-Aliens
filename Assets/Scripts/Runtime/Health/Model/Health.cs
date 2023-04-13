using System;
using HumansVsAliens.Tools;
using HumansVsAliens.View;

namespace HumansVsAliens.Model
{
    public sealed class Health : IHealth
    {
        private readonly IHealthView _view;

        public Health(IHealthView view, int value)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            Value = value.ThrowIfLessThanOrEqualsToZeroException();
        }

        public int Value { get; private set; }
        
        public bool IsAlive => Value > 0;
    
        public void TakeDamage(int damage)
        {
            if (!IsAlive)
                throw new InvalidOperationException($"Health isn't alive!");
            
            Value = Math.Max(0, Value - damage);
            
            if(!IsAlive)
                _view.Die();
        }
    }
}