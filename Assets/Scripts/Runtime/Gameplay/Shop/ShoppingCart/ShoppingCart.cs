using System;

namespace HumansVsAliens.Gameplay
{
    public class ShoppingCart : IShoppingCart
    {
        public ShoppingCart(IGood good)
        {
            Good = good ?? throw new ArgumentNullException(nameof(good));
        }

        public IGood Good { get; private set; }

        public void SwitchGood(IGood good)
        {
            if (Good == good)
                throw new ArgumentOutOfRangeException(nameof(good));

            Good = good ?? throw new ArgumentNullException(nameof(good));
        }
    }
}