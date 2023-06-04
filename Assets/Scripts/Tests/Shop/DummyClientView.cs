using HumansVsAliens.Gameplay;

namespace HumansVsAliens.Tests.Shop
{
    public class DummyClientView : IClientView
    {
        public void BuyGood(IGoodViewData goodData)
        {
        }

        public void SelectGood(IGoodViewData goodData, int price)
        {
            
        }
    }
}