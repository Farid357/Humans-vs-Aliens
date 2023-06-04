using System;
using System.Collections.Generic;
using System.Linq;

namespace HumansVsAliens.Gameplay
{
    public class ShopWithDiscounts : IShopWithDiscounts
    {
        private readonly IDictionary<IGood, int> _prices;
        private readonly IShop _shop;
        
        public ShopWithDiscounts(IShop shop)
        {
            _shop = shop ?? throw new ArgumentNullException(nameof(shop));
            _prices = new Dictionary<IGood, int>();
        }

        public IGoodViewData GetData(IGood good) => _shop.GetData(good);

        public int CalculatePrice(IGood good) => _prices[good];

        public void Add(IGood good, IGoodData data)
        {
            _shop.Add(good, data);
            _prices.Add(good, data.Price);
        }

        public void SetDiscount(int percents)
        {
            for (int i = 0; i < _prices.Keys.Count; i++)
            {
                SetDiscount(_prices.Keys.ElementAt(i), percents);
            }
        }

        public void SetDiscount(IGood good, int percents)
        {
            _prices[good] -= _prices[good] / 100 * percents;
        }
    }
}