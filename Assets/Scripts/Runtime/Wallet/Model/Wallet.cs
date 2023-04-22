using System;
using HumansVsAliens.Tools;
using HumansVsAliens.View;

namespace HumansVsAliens.Model
{
    public sealed class Wallet : IWallet
    {
        private readonly IWalletView _view;

        public Wallet(int money, IWalletView view)
        {
            Money = money.ThrowIfLessThanZeroException();
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public int Money { get; private set; }

        public bool CanTake(int money)
        {
            return Money - money >= 0;
        }

        public void Put(int money)
        {
            Money += money;
            _view.Visualize(Money);
        }

        public void Take(int money)
        {
            Money -= money;
            _view.Visualize(Money);
        }
    }
}