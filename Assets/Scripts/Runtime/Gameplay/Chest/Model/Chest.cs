using System;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public class Chest : IChest
    {
        private readonly IChestView _view;
        private readonly IReward _reward;

        public Chest(IReward reward)
        {
            _reward = reward ?? throw new ArgumentNullException(nameof(reward));
        }

        public bool IsOpen { get; private set; }
        
        public void Open()
        {
            if (IsOpen)
                throw new InvalidOperationException($"The chest is already opened!");

            IsOpen = true;
            _reward.Receive();
        }

        public void Destroy()
        {
            _view.Destroy();
        }
    }
}