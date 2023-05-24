using System;
using SaveSystem;

namespace HumansVsAliens.Gameplay
{
    public sealed class WalletWithSave : IWallet
    {
        private readonly IWallet _wallet;
        private readonly ISaveStorage<int> _moneyStorage;

        public WalletWithSave(IWallet wallet, ISaveStorage<int> moneyStorage)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _moneyStorage = moneyStorage ?? throw new ArgumentNullException(nameof(moneyStorage));

            if (_moneyStorage.HasSave() && _moneyStorage.Load() != _wallet.Money)
                throw new InvalidOperationException("Put saved money to wallet!");
        }

        public int Money => _wallet.Money;

        public bool CanTake(int money) => _wallet.CanTake(money);

        public void Take(int money)
        {
            _wallet.Take(money);
            Save();
        }

        public void Put(int money)
        {
            _wallet.Put(money);
            Save();
        }

        private void Save()
        {
            _moneyStorage.Save(_wallet.Money);
        }
    }
}