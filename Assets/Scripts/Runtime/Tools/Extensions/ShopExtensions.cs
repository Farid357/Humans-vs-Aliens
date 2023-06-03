using HumansVsAliens.Gameplay;

namespace HumansVsAliens.Tools
{
    public static class ShopExtensions
    {
        public static int GetPrice(this IShop shop, IGood good)
        {
            return shop.Goods[good].Price;
        }
    }
}