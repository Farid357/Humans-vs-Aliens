namespace HumansVsAliens.Gameplay
{
    public interface IClientView
    {
        void BuyGood(IGoodData goodData);
        
        void SelectGood(IGoodData goodData);
    }
}