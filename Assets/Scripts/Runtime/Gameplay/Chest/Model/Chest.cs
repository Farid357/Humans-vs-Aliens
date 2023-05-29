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

        public IOnlyDestroyChestView View => _view;

        public void Open()
        {
            if (IsOpen)
                throw new InvalidOperationException($"The chest is already opened!");

            if (_view.IsActive == false)
                throw new InvalidOperationException($"The view is destroyed! You can't open this chest!");

            IsOpen = true;
            _reward.Receive();
            _view.Open();
        }
    }
}