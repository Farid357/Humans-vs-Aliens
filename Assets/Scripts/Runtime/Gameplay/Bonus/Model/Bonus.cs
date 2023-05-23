using System;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public class Bonus : IBonus
    {
        private readonly IBonusView _view;
        private bool _wasPickedUp;

        public Bonus(IBonusView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public void PickUp()
        {
            if (_wasPickedUp)
                throw new InvalidOperationException($"Bonus is already picked!");
            
            _wasPickedUp = true;
            _view.PickUp();
        }
    }
}