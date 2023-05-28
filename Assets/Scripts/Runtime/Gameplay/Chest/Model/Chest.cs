using System;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public class Chest : IChest
    {
        private readonly IChestView _view;
        private readonly IReward _reward;

        public Chest(IChestView view, IReward reward)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _reward = reward ?? throw new ArgumentNullException(nameof(reward));
        }

        public bool IsOpen { get; private set; }
        
        public void Open()
        {
            if (IsOpen)
                throw new InvalidOperationException($"Chest is already opened!");
            
            IsOpen = true;
            _reward.Receive();
            _view.Open();
        }
    }
}