using System.Collections.Generic;
using HumansVsAliens.Gameplay;

namespace HumansVsAliens.Tools
{
    public static class ShopExtensions
    {
        public static void Add(this IShop shop, IDictionary<IGood, IGoodData> goods)
        {
            foreach ((IGood good, IGoodData goodData) in goods)
            {
                shop.Add(good, goodData);
            }
        }
    }
}