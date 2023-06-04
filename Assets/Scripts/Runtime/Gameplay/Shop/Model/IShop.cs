namespace HumansVsAliens.Gameplay
{
    public interface IShop : IReadOnlyShop
    {
        void Add(IGood good, IGoodData data);
    }
}