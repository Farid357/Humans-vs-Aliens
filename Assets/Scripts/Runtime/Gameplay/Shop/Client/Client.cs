using System;

namespace HumansVsAliens.Gameplay
{
    public class Client : IClient
    {
        private readonly IWallet _wallet;
        private readonly IReadOnlyShoppingCart _shoppingCart;

        public Client(IWallet wallet, IReadOnlyShoppingCart shoppingCart)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _shoppingCart = shoppingCart ?? throw new ArgumentNullException(nameof(shoppingCart));
        }

        public bool HasEnoughMoney => _wallet.Money >= GoodPrice;
        
        private int GoodPrice => _shoppingCart.Good.Data.Price;
        
        public void BuyGood()
        {
            if (!HasEnoughMoney)
                throw new InvalidOperationException($"Client doesn't have enough money!");
            
            _shoppingCart.Good.Buy();
            _wallet.Take(GoodPrice);
        }
    }
}