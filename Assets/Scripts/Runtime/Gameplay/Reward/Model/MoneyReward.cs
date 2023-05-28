using HumansVsAliens.Tools;
using System;

namespace HumansVsAliens.Gameplay
{
    public class MoneyReward : IReward
    {
        private readonly IWallet _wallet;
        private readonly int _money;

        public MoneyReward(IWallet wallet, int money)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _money = money.ThrowIfLessThanOrEqualsToZeroException();
        }

        public void Receive()
        {
            _wallet.Put(_money);
        }
    }
}