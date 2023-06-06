using System;

namespace HumansVsAliens.Gameplay
{
    public class ChestBonus : IBonus
    {
        private readonly IBonus _bonus;
        private readonly IChestFactory _chestFactory;
      
        private IChestWithView _lastChest;

        public ChestBonus(IBonus bonus, IChestFactory chestFactory)
        {
            _bonus = bonus ?? throw new ArgumentNullException(nameof(bonus));
            _chestFactory = chestFactory ?? throw new ArgumentNullException(nameof(chestFactory));
        }

        public bool CanBePicked => _bonus.CanBePicked;

        public void PickUp()
        {
            if (_lastChest != null && _lastChest.IsActive)
                _lastChest.Destroy();
            
            _lastChest = _chestFactory.Create();
            _bonus.PickUp();
        }
    }
}