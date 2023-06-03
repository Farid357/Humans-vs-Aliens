namespace HumansVsAliens.Gameplay
{
    public interface IClient : IReadOnlyClient
    {
        void SelectGood(IGood good);
        
        void BuyGood();
    }
}