using System;

namespace HumansVsAliens.Gameplay
{
    public class Client : IClient
    {
        private readonly IReadOnlyShop _shop;
        private readonly IWallet _wallet;
        private readonly IClientView _view;

        private IGood _good;

        public Client(IClientView view, IReadOnlyShop shop, IWallet wallet)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _shop = shop ?? throw new ArgumentNullException(nameof(shop));
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
        }

        public bool HasEnoughMoney => _wallet.Money >= _shop.CalculatePrice(_good);

        public bool HasGood => _good != null;

        public void SelectGood(IGood good)
        {
            if (_good == good)
                throw new ArgumentOutOfRangeException(nameof(good));

            _good = good ?? throw new ArgumentNullException(nameof(good));
            _view.SelectGood(_shop.GetData(good), _shop.CalculatePrice(good));
        }

        public void BuySelectedGood()
        {
            if (!HasEnoughMoney)
                throw new InvalidOperationException($"Client doesn't have enough money!");

            if (!HasGood)
                throw new InvalidOperationException(nameof(HasGood));

            _wallet.Take(_shop.CalculatePrice(_good));
            _good.Use();
            _view.BuyGood(_shop.GetData(_good));
        }
    }
}