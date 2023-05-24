using System;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public class Ability : IAbility
    {
        private readonly IAbilityView _view;

        public Ability(IAbilityView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public bool IsActive { get; private set; }

        public void Activate()
        {
            if (IsActive)
                throw new InvalidOperationException($"Ability is already active! you can't activate it!");

            IsActive = true;
            _view.Activate();
        }

        public void Deactivate()
        {
            if (!IsActive)
                throw new InvalidOperationException($"Ability is already deactivated! you can't deactivate it!");

            IsActive = false;
            _view.Deactivate();
        }
    }
}