namespace HumansVsAliens.Gameplay
{
    public interface IGoodData
    {
        string Name { get; }
        
        string Description { get; }

        int Price { get; }

        void SetPrice(int newPrice);
    }
}