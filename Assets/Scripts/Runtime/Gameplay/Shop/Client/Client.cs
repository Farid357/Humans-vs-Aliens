using System;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class Client : IClient
    {
        private readonly IShop _shop;
        private readonly IWallet _wallet;
        private readonly IClientView _view;
       
        private IGood _good;

        public Client(IClientView view, IShop shop, IWallet wallet)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _shop = shop ?? throw new ArgumentNullException(nameof(shop));
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
        }

        public bool HasEnoughMoney => _wallet.Money >= _shop.GetPrice(_good);
        
        public bool HasGood => _good != null;

        private IGoodData GoodData => _shop.Goods[_good];
        
        public void SelectGood(IGood good)
        {
            if (_good == good)
                throw new ArgumentOutOfRangeException(nameof(good));
            
            _good = good ?? throw new ArgumentNullException(nameof(good));
            _view.SelectGood(GoodData);
        }

        public void BuyGood()
        {
            if (!HasEnoughMoney)
                throw new InvalidOperationException($"Client doesn't have enough money!");

            if (!HasGood)
                throw new InvalidOperationException(nameof(HasGood));
            
            _wallet.Take(GoodData.Price);
            _good.Buy();
            _view.BuyGood(GoodData);
        }
    }
}