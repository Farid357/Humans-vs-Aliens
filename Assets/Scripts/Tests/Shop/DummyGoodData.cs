using HumansVsAliens.Gameplay;

namespace HumansVsAliens.Tests.Shop
{
    public class DummyGoodData : IGoodData
    {
        public DummyGoodData(int price)
        {
            Price = price;
        }

        public string Name { get; }
        
        public string Description { get; }
        
        public int Price { get; }
        
        public void SetPrice(int newPrice)
        {
            
        }
    }
}