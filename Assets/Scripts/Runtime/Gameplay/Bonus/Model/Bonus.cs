using System;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public class Bonus : IBonus
    {
        private readonly IBonusView _view;

        public Bonus(IBonusView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public bool CanBePicked { get; private set; } = true;

        public void PickUp()
        {
            if (!CanBePicked)
                throw new InvalidOperationException($"Bonus is already picked!");
            
            CanBePicked = false;
            _view.PickUp();
        }
    }
}