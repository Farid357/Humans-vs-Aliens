namespace HumansVsAliens.Gameplay
{
    public interface IGoodFactory
    {
        (IGood, IGoodData) Create();
    }
}