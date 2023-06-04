namespace HumansVsAliens.Gameplay
{
    public interface IShopWithDiscounts : IShop
    {
        void SetDiscount(int percents);

        void SetDiscount(IGood good, int percents);
    }
}