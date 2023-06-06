using System;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class PutMoneyCheat : ICheat
    {
        private readonly IWallet _wallet;
        private readonly int _money;

        public PutMoneyCheat(IWallet wallet, int money)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _money = money.ThrowIfLessThanOrEqualsToZeroException();
        }

        public void Activate()
        {
            _wallet.Put(_money);
        }
    }
}