using System;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class PutMoneyCommand : ICommand
    {
        private readonly IWallet _wallet;
        private readonly int _money;

        public PutMoneyCommand(IWallet wallet, int money)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _money = money.ThrowIfLessThanOrEqualsToZeroException();
        }

        public void Execute()
        {
            _wallet.Put(_money);
        }
    }
}