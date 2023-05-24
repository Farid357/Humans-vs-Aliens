namespace HumansVsAliens.Gameplay
{
    public interface IShoppingCart : IReadOnlyShoppingCart
    {
        void SwitchGood(IGood good);
    }
}