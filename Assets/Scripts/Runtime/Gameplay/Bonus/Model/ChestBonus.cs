using System;

namespace HumansVsAliens.Gameplay
{
    public class ChestBonus : IBonus
    {
        private readonly IBonus _bonus;
        private readonly IChestFactory _chestFactory;
      
        public ChestBonus(IBonus bonus, IChestFactory chestFactory)
        {
            _bonus = bonus ?? throw new ArgumentNullException(nameof(bonus));
            _chestFactory = chestFactory ?? throw new ArgumentNullException(nameof(chestFactory));
        }

        public bool CanBePicked => _bonus.CanBePicked;

        public void PickUp()
        {
            _chestFactory.CreateLocal();
            _bonus.PickUp();
        }
    }
}