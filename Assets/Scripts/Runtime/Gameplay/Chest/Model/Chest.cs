using System;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public class Chest : IChest
    {
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
    }
}