namespace HumansVsAliens.Gameplay
{
    public interface IClient
    {
        bool HasEnoughMoney { get; }

        void BuyGood();
    }
}