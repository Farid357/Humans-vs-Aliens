namespace HumansVsAliens.Gameplay
{
    public interface IClientView
    {
        void BuyGood(IGoodViewData goodData);
        
        void SelectGood(IGoodViewData goodData, int price);
    }
}