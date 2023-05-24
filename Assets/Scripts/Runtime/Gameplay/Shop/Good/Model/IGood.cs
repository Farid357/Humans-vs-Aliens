namespace HumansVsAliens.Gameplay
{
    public interface IGood
    {
        IGoodData Data { get; }

        bool IsBought { get; }
        
        void Buy();
    }
}